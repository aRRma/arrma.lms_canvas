using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Courses;
using CanvasApiCore.Models.Users;
using CanvasApiCore.Models.Query_objects;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// Запросы к API courses
    /// </summary>
    public static class CoursesQueries
    {
        /// <summary>
        /// Запросить список курсов текущего пользователя.
        /// </summary>
        /// <param name="addParams">Объект дополнительных параметров для запроса</param>
        /// <returns>Список объектов курс "Course".</returns>
        public static async Task<List<CourseJson>> ListYourCoursesAsync(ListYourCoursesParams addParams)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.index

            string _queryParams = null;

            if (addParams.enrollment_type != CourseEnrollmentType.NONE)
                _queryParams += "enrollment_type=" + addParams.enrollment_type.ToString().ToLower() + "&";
            if (addParams.enrollment_role_id != null)
                _queryParams += "enrollment_role_id=" + addParams.enrollment_role_id + "&";
            if (addParams.enrollment_state != CourseEnrollmentState.NONE)
                _queryParams += "enrollment_state=" + addParams.enrollment_state.ToString().ToLower() + "&";
            if (addParams.exclude_blueprint_courses != null)
                _queryParams += "exclude_blueprint_courses=" + addParams.exclude_blueprint_courses.ToString().ToLower() + "&";
            if (!addParams.include.Contains(CourseInclude.NONE))
                foreach (var item in addParams.include)
                    _queryParams += "include[]=" + item.ToString().ToLower() + "&";
            if (!addParams.state.Contains(CourseState.NONE))
                foreach (var item in addParams.state)
                    _queryParams += "state[]=" + item.ToString().ToLower() + "&";
            _queryParams += "per_page=" + 50 + "&";

            string url = ApiController.GetV1Url("v1/courses/", _queryParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CourseJson>>(data.Result);
        }
        /// <summary>
        /// Запросить список курсов для конкретного пользователя.
        /// </summary>
        /// <param name="userId">ID пользователя на курсе</param>
        /// <param name="addParams">Объект дополнительных параметров для запроса</param>
        /// <returns>Список объектов курс "Course".</returns>
        public static async Task<List<CourseJson>> ListCoursesForUserAsync(string userId, ListCoursesForUserParams addParams)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.user_index

            string _queryParams = null;

            if (!addParams.include.Contains(CourseInclude.NONE))
                foreach (var item in addParams.include)
                    _queryParams += "include[]=" + item.ToString().ToLower() + "&";
            if (!addParams.state.Contains(CourseState.NONE))
                foreach (var item in addParams.state)
                    _queryParams += "state[]=" + item.ToString().ToLower() + "&";
            if (addParams.enrollment_state != CourseEnrollmentState.NONE)
                _queryParams += "enrollment_state=" + addParams.enrollment_state + "&";

            string url = ApiController.GetV1Url("v1/users/" + userId + "/courses", _queryParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CourseJson>>(data.Result);
        }
        /// <summary>
        /// Запросить список пользователей на курсе.
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="addParams">Объект дополнительных параметров для запроса.</param>
        /// <returns>Список объектов пользователь "User".</returns>
        public static async Task<List<UserJson>> ListUsersInCourseAsync(string courseId, ListUsersInCourseParams addParams)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.users

            string _queryParams = null;

            if (addParams.search_term != null)
                _queryParams += "search_term=" + Uri.EscapeDataString(addParams.search_term) + "&";
            if (addParams.enrollment_type != UserEnrollmentType.NONE)
                _queryParams += "enrollment_type[]=" + addParams.enrollment_type.ToString().ToLower() + "&";
            if (addParams.enrollment_role_id != null)
                _queryParams += "enrollment_role_id=" + addParams.enrollment_role_id + "&";
            if (!addParams.include.Contains(UserInclude.NONE))
                foreach (var item in addParams.include)
                    _queryParams += "include[]=" + item.ToString().ToLower() + "&";
            if (addParams.user_id != null)
                _queryParams += "user_id=" + addParams.user_id + "&";
            if (addParams.user_ids != null)
                for (int i = 0; i < addParams.user_ids.Length; i++)
                    _queryParams += "user_ids[]=" + addParams.user_ids[i] + "&";
            if (!addParams.enrollment_state.Contains(UserEnrollmentState.NONE))
                foreach (var item in addParams.enrollment_state)
                    _queryParams += "enrollment_state[]=" + item.ToString().ToLower() + "&";

            int pages = 1;

            if (addParams.number_students is > 0)
            {
                _queryParams += "per_page=" + addParams.number_students + "&";
                pages = (int)addParams.number_students / 50 + 1;
            }

            List<UserJson> users = new List<UserJson>();

            for (int i = 1; i <= pages; i++)
            {
                string url = ApiController.GetV1Url("v1/courses/" + courseId + "/users", _queryParams + $"page={i}&");
                using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<UserJson>>(data.Result);
                if (json == null) continue;
                foreach (var item in json)
                    users.Add(item);
            }
            return users;
        }
    }
}
