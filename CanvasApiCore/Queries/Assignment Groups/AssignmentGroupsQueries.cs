using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CanvasApiCore;
using CanvasApiCore.Models.Assignment_Group;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// Запросы к API AssignmentGroups
    /// </summary>
    public class AssignmentGroupsQueries
    {
        /// <summary>
        /// Запросить список групп заданий на курсе.
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="include">Дополнительные параметры запроса</param>
        /// <returns>Объект группы заданий "AssignmentGroup".</returns>
        public static async Task<List<AssignmentGroup>> ListAssignmentGroupsAsync(string courseId, AssignmentGroupInclude include = AssignmentGroupInclude.NONE)
        {
            // see https://canvas.instructure.com/doc/api/assignment_groups.html#method.assignment_groups.index
            
            string _queryParams = null;

            if (include != AssignmentGroupInclude.NONE)
                _queryParams += "include=" + include.ToString().ToLower() + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignment_groups", _queryParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AssignmentGroup>>(data.Result);
        }
    }
}
