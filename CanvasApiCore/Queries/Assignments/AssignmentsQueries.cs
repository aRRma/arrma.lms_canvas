using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CanvasApiCore.Models;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// Запросы к API Assignments
    /// </summary>
    public static class AssignmentsQueries
    {
        /// <summary>
        /// Запросить список заданий на курсе.
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="addParams">Объект дополнительных параметров для запроса</param>
        /// <param name ="cancel">Токен завершения асинхронной задачи</param>
        /// <returns>Список объектов заданий "Assignment".</returns>
        /// <exception cref="Newtonsoft.Json.JsonException">Ошибка десериализации</exception>
        /// <exception cref="Exception">Ошибка HTTP запроса</exception>
        public static async Task<List<AssignmentJson>> ListAssignmentsAsync(string courseId, ListAssignmentsParams addParams, CancellationToken cancel = default)
        {
            // see https://canvas.instructure.com/doc/api/assignments.html#method.assignments_api.index

            string _queryParams = null;

            if (!addParams.include.Contains(AssignmentInclude.NONE))
                foreach (var item in addParams.include)
                    _queryParams += "include[]=" + item.ToString().ToLower() + "&";
            if (addParams.search_term != null)
                _queryParams += "search_term=" + Uri.EscapeDataString(addParams.search_term) + "&";
            if (addParams.override_assignment_dates != null)
                _queryParams += "override_assignment_dates=" + addParams.override_assignment_dates.ToString().ToLower() + "&";
            if (addParams.needs_grading_count_by_section != null)
                _queryParams += "needs_grading_count_by_section=" + addParams.needs_grading_count_by_section.ToString().ToLower() + "&";
            if (addParams.bucket != AssignmentBucket.NONE)
                _queryParams += "bucket=" + addParams.bucket.ToString().ToLower() + "&";
            if (addParams.assignment_ids != null)
                for (int i = 0; i < addParams.assignment_ids.Length; i++)
                    _queryParams += "assignment_ids[]=" + addParams.assignment_ids[i] + "&";
            if (addParams.order_by != AssignmentOrderBy.NONE)
                _queryParams += "order_by=" + addParams.order_by.ToString().ToLower() + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignments", _queryParams);
            var data = (await ApiController.HttpClient.GetAsync(url, cancel).ConfigureAwait(false)).Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<List<AssignmentJson>>(data.Result);
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
