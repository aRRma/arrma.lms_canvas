using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CanvasApiCore.Models;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// Запросы к API Submissions
    /// </summary>
    public static class SubmissionsQueries
    {
        /// <summary>
        /// Запросить список представлений для заданий и для n-го числа студентов
        /// </summary>
        /// <remarks>Есть различия в возвращаемом объекте запросом</remarks>
        /// <remarks>Если параметр student_ids опущен, то вернутся представления для текущего пользователя</remarks>
        /// <param name="courseId">ID курса</param>
        /// <param name="addParams">Объект дополнительных параметров для запроса</param>
        /// <param name ="cancel">Токен завершения асинхронной задачи</param>
        /// <returns>Если grouped=true, то список "StudentSubmissions". А если grouped=false, то список "Submission"</returns>
        /// <exception cref="Newtonsoft.Json.JsonException">Ошибка десериализации</exception>
        /// <exception cref="Exception">Ошибка HTTP запроса</exception>
        public static async Task<List<GroupedSubmissions>> ListSubmissionsForMultiAssignmentsAsync(string courseId, ListMultiSubmParams addParams, CancellationToken cancel = default)
        {
            // see https://canvas.instructure.com/doc/api/submissions.html#method.submissions_api.for_students

            string _queryParams = null;

            //if (addParams.student_ids != null)
            //    for (int i = 0; i < addParams.student_ids.Length; i++)
            //        _queryParams += "student_ids[]=" + addParams.student_ids[i] + "&";
            if (addParams.assignment_ids != null)
                for (int i = 0; i < addParams.assignment_ids.Length; i++)
                    _queryParams += "assignment_ids[]=" + addParams.assignment_ids[i] + "&";
            if (addParams.grouped != null) _queryParams += "grouped=" + addParams.grouped.ToString().ToLower() + "&";
            if (addParams.post_to_sis != null) _queryParams += "post_to_sis=" + addParams.post_to_sis.ToString().ToLower() + "&";
            if (addParams.submitted_since != null) _queryParams += "submitted_since=" + addParams.submitted_since.Value.ToString("u") + "&";
            if (addParams.grading_period_id != null) _queryParams += "grading_period_id=" + addParams.grading_period_id + "&";
            if (addParams.workflow_state != SubmissionWorkflowState.NONE)
                _queryParams += "workflow_state=" + addParams.workflow_state.ToString().ToLower() + "&";
            if (addParams.enrollment_state != SubmissionEnrollmentState.NONE)
                _queryParams += "enrollment_state=" + addParams.enrollment_state.ToString().ToLower() + "&";
            if (addParams.state_based_on_date != null)
                _queryParams += "state_based_on_date=" + addParams.state_based_on_date.ToString().ToLower() + "&";
            if (addParams.order != SubmissionOrder.NONE)
                _queryParams += "order=" + addParams.order.ToString().ToLower() + "&";
            if (addParams.order_direction != SubmissionOrderDir.NONE)
                _queryParams += "order_direction" + addParams.order_direction.ToString().ToLower() + "&";
            if (!addParams.include.Contains(SubmissionInclude.NONE))
                foreach (var item in addParams.include)
                    _queryParams += "include[]=" + item.ToString().ToLower() + "&";

            int pages = 1;

            if (addParams.student_ids.Length > 0)
            {
                _queryParams += "per_page=" + addParams.student_ids.Length + "&";
                pages = addParams.student_ids.Length / 50 + 1;
            }

            List<GroupedSubmissions> submissions = new List<GroupedSubmissions>();

            for (int i = 1; i <= pages; i++)
            {
                string studentsIds = string.Join("", addParams.student_ids.Skip(50 * (i - 1)).Take(50).Select(x => "student_ids[]=" + x + "&").ToArray());
                string url = ApiController.GetV1Url("v1/courses/" + courseId + "/students/submissions", _queryParams + studentsIds + $"page={i}&");
                var data = (await ApiController.HttpClient.GetAsync(url, cancel).ConfigureAwait(false)).Content.ReadAsStringAsync();
                try
                {
                    var json = JsonConvert.DeserializeObject<List<GroupedSubmissions>>(data.Result);
                    if (json == null) continue;
                    foreach (var item in json)
                        submissions.Add(item);
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(JsonException))
                        throw new JsonException($"URL: {url}\nError JSON: {data.Result}\nMessage: {e.Message}\n", e.InnerException);
                    throw new Exception($"URL: {url}\nMessage: {e.Message}\n", e.InnerException);
                }
            }
            return submissions;
        }
        /// <summary>
        /// Запросить представление одного задания для конкретного пользователя
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="assignmentId">ID задания из курса</param>
        /// <param name="userId">ID пользователя на курсе</param>
        /// <param name="include">Дополнительные параметры запроса</param>
        /// <param name ="cancel">Токен завершения асинхронной задачи</param>
        /// <returns>Объект представления "Submission"</returns>
        /// <exception cref="Newtonsoft.Json.JsonException">Ошибка десериализации</exception>
        /// <exception cref="Exception">Ошибка HTTP запроса</exception>
        public static async Task<SubmissionJson> GetSingleSubmissionAsync(string courseId, string assignmentId, string userId, List<SubmissionInclude> include = null, CancellationToken cancel = default)
        {
            // see https://canvas.instructure.com/doc/api/submissions.html#method.submissions_api.show

            string _queryParams = null;

            if (include != null)
                foreach (var item in include)
                    _queryParams += "include[]=" + item.ToString().ToLower() + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignments/" + assignmentId + "/submissions/" + userId, _queryParams);
            var data = (await ApiController.HttpClient.GetAsync(url, cancel).ConfigureAwait(false)).Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<SubmissionJson>(data.Result);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(JsonException))
                    throw new JsonException($"URL: {url}\nError JSON: {data.Result}\nMessage: {e.Message}\n", e.InnerException);
                throw new Exception($"URL: {url}\nMessage: {e.Message}\n", e.InnerException);
            }
        }
    }
}