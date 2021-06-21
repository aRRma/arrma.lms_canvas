using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CanvasApiCore;
using CanvasApiCore.Models;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// Запросы к API AssignmentGroups
    /// </summary>
    public static class AssignmentGroupsQueries
    {
        /// <summary>
        /// Запросить список групп заданий на курсе.
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="include">Дополнительные параметры запроса</param>
        /// <param name ="cancel">Токен завершения асинхронной задачи</param>
        /// <returns>Объект группы заданий "AssignmentGroup".</returns>
        /// <exception cref="Newtonsoft.Json.JsonException">Ошибка десериализации</exception>
        /// <exception cref="Exception">Ошибка HTTP запроса</exception>
        public static async Task<List<AssignmentGroupJson>> ListAssignmentGroupsAsync(string courseId, AssignmentGroupInclude include = AssignmentGroupInclude.NONE, CancellationToken cancel = default)
        {
            // see https://canvas.instructure.com/doc/api/assignment_groups.html#method.assignment_groups.index

            string _queryParams = null;

            if (include != AssignmentGroupInclude.NONE)
                _queryParams += "include=" + include.ToString().ToLower() + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignment_groups", _queryParams);
            var data = (await ApiController.HttpClient.GetAsync(url, cancel).ConfigureAwait(false)).Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<List<AssignmentGroupJson>>(data.Result);
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
