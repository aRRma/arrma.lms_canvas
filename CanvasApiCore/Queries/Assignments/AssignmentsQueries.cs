using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Assignments;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class AssignmentsQueries
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="searchTerm"></param>
        /// <param name="bucket"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public static async Task<List<Assignment>> ListAssignmentsAsync(string courseId, string searchTerm = null, AssignmentBucket bucket = AssignmentBucket.UPCOMING, AssignmentOrderBy orderBy = AssignmentOrderBy.NAME, List<AssignmentInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/assignments.html#method.assignments_api.index

            string _term = null;
            string _bucket = null;
            string _orderBy = null;
            string _include = null;
            string addParams = null;

            if (!string.IsNullOrEmpty(searchTerm)) _term = "search_term=" + Uri.EscapeDataString(searchTerm);

            _bucket = bucket switch
            {
                AssignmentBucket.NONE => string.Empty,
                AssignmentBucket.PAST => "bucket=" + AssignmentBucket.PAST.ToString().ToLower(),
                AssignmentBucket.OVERDUE => "bucket=" + AssignmentBucket.OVERDUE.ToString().ToLower(),
                AssignmentBucket.UNDATED => "bucket=" + AssignmentBucket.UNDATED.ToString().ToLower(),
                AssignmentBucket.UNGRADED => "bucket=" + AssignmentBucket.UNGRADED.ToString().ToLower(),
                AssignmentBucket.UNSUBMITTED => "bucket=" + AssignmentBucket.UNSUBMITTED.ToString().ToLower(),
                AssignmentBucket.UPCOMING => "bucket=" + AssignmentBucket.UPCOMING.ToString().ToLower(),
                AssignmentBucket.FUTURE => "bucket=" + AssignmentBucket.FUTURE.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(bucket), bucket, "Unknown AssignmentBucket enum type")
            };

            _orderBy = orderBy switch
            {
                AssignmentOrderBy.NONE => String.Empty,
                AssignmentOrderBy.NAME => "order_by=" + AssignmentOrderBy.NAME.ToString().ToLower(),
                AssignmentOrderBy.POSITIONS => "order_by=" + AssignmentOrderBy.POSITIONS.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(orderBy), orderBy, "Unknown AssignmentOrderBy enum type")
            };

            if (include != null)
            {
                foreach (var item in include)
                    _include += "include[]=" + item.ToString().ToLower() + "&";
                _include = _include.Remove(_include.LastIndexOf("&"));
            }

            if (!string.IsNullOrEmpty(_term)) addParams += _term + "&";
            if (!string.IsNullOrEmpty(_bucket)) addParams += _bucket + "&";
            if (!string.IsNullOrEmpty(_orderBy)) addParams += _orderBy + "&";
            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";

            string url = ApiController.GetV1Url("v1/courses/" + courseId + "/assignments", addParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Assignment>>(data.Result);
        }
    }
}
