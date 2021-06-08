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
    /// 
    /// </summary>
    public class AssignmentGroupsQueries
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public static async Task<List<AssignmentGroup>> ListAssignmentGroupsAsync(string courseId, AssignmentGroupInclude include = AssignmentGroupInclude.NONE)
        {
            // see https://canvas.instructure.com/doc/api/assignment_groups.html#method.assignment_groups.index

            string _include;
            string addParams = null;

            _include = include switch
            {
                AssignmentGroupInclude.NONE => string.Empty,
                AssignmentGroupInclude.ASSIGNMENTS => "include=" + AssignmentGroupInclude.ASSIGNMENTS.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(include), include, "Unknown AssignmentGroupInclude enum type")
            };

            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignment_groups", addParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AssignmentGroup>>(data.Result);
        }
    }
}
