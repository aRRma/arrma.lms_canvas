using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Submissions;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// Запросы к API submissions
    /// </summary>
    public class SubmissionsQueries
    {
        /// <summary>
        /// Запросить представления для списка заданий и для n-го числа студентов
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="addParams">Обьект дополнительных параметров для запроса</param>
        /// <returns></returns>
        public static async Task<List<StudentSubmissions>> ListSubmissionsForMultiAssignmentsAsync(string courseId, ListMultiSubmParams addParams)
        {
            // see https://canvas.instructure.com/doc/api/submissions.html#method.submissions_api.for_students

            string _queryParams = null;

            if (addParams.student_ids != null)
                for (int i = 0; i < addParams.student_ids.Length; i++)
                    _queryParams += "student_ids[]=" + addParams.student_ids[i] + "&";

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

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/students/submissions", _queryParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<StudentSubmissions>>(data.Result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="assignmentId"></param>
        /// <param name="userId"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public static async Task<Submission> GetSingleSubmissionAsync(string courseId, string assignmentId, string userId, List<SubmissionInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/submissions.html#method.submissions_api.show

            string _include = null;

            if (include != null)
                foreach (var item in include)
                    _include += "include[]=" + item.ToString().ToLower() + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignments/" + assignmentId + "/submissions/" + userId, _include);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Submission>(data.Result);
        }
    }
}
