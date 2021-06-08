using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Courses;
using CanvasApiCore.Models.Users;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class CoursesQueries
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <param name="state"></param>
        /// <param name="enrollment"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public static async Task<List<Course>> ListYourCoursesAsync(CourseEnrollmentRole role = CourseEnrollmentRole.TEACHER, CourseState state = CourseState.AVAILABLE, CourseEnrollmentState enrollment = CourseEnrollmentState.ACTIVE, List<CourseInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.index

            string _role;
            string _state;
            string _enrollment;
            string _include = null;
            string addParams = null;

            _role = role switch
            {
                CourseEnrollmentRole.NONE => string.Empty,
                CourseEnrollmentRole.STUDENT => "enrollment_type=" + CourseEnrollmentRole.STUDENT.ToString().ToLower(),
                CourseEnrollmentRole.TEACHER => "enrollment_type=" + CourseEnrollmentRole.TEACHER.ToString().ToLower(),
                CourseEnrollmentRole.TA => "enrollment_type=" + CourseEnrollmentRole.TA.ToString().ToLower(),
                CourseEnrollmentRole.OBSERVER => "enrollment_type=" + CourseEnrollmentRole.OBSERVER.ToString().ToLower(),
                CourseEnrollmentRole.DESIGNER => "enrollment_type=" + CourseEnrollmentRole.DESIGNER.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Unknown CourseEnrollmentRole enum type")
            };

            _state = state switch
            {
                CourseState.NONE => string.Empty,
                CourseState.UNPUBLISHED => "state[]=" + CourseState.UNPUBLISHED.ToString().ToLower(),
                CourseState.AVAILABLE => "state[]=" + CourseState.AVAILABLE.ToString().ToLower(),
                CourseState.COMPLETED => "state[]=" + CourseState.COMPLETED.ToString().ToLower(),
                CourseState.DELETED => "state[]=" + CourseState.DELETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown CourseState enum type")
            };

            _enrollment = enrollment switch
            {
                CourseEnrollmentState.NONE => string.Empty,
                CourseEnrollmentState.ACTIVE => "enrollment_state=" + CourseEnrollmentState.ACTIVE.ToString().ToLower(),
                CourseEnrollmentState.INVITED_OR_PENDING => "enrollment_state=" + CourseEnrollmentState.INVITED_OR_PENDING.ToString().ToLower(),
                CourseEnrollmentState.COMPLETED => "enrollment_state=" + CourseEnrollmentState.COMPLETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown CourseEnrollmentState enum type")
            };

            if (include != null)
            {
                foreach (var item in include)
                {
                    if (item != CourseInclude.NONE &&
                        item != CourseInclude.ALL_COURSES &&
                        item != CourseInclude.PERMISSIONS)
                    {
                        _include += $"include[]=" + item.ToString().ToLower() + "&";
                    }
                }
                _include = _include.Remove(_include.LastIndexOf("&"));
            }

            if (!string.IsNullOrEmpty(_role)) addParams += _role + "&";
            if (!string.IsNullOrEmpty(_state)) addParams += _state + "&";
            if (!string.IsNullOrEmpty(_enrollment)) addParams += _enrollment + "&";
            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";

            string url = ApiController.GetV1Url("v1/courses/", addParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Course>>(data.Result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <param name="enrollment"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public static async Task<List<Course>> ListCoursesForUserAsync(string userId = "23392", CourseState state = CourseState.AVAILABLE, CourseEnrollmentState enrollment = CourseEnrollmentState.ACTIVE, List<CourseInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.user_index

            string _state;
            string _enrollment;
            string _include = null;
            string addParams = null;

            _state = state switch
            {
                CourseState.NONE => string.Empty,
                CourseState.UNPUBLISHED => "state[]=" + CourseState.UNPUBLISHED.ToString().ToLower(),
                CourseState.AVAILABLE => "state[]=" + CourseState.AVAILABLE.ToString().ToLower(),
                CourseState.COMPLETED => "state[]=" + CourseState.COMPLETED.ToString().ToLower(),
                CourseState.DELETED => "state[]=" + CourseState.DELETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown CourseState enum type")
            };

            _enrollment = enrollment switch
            {
                CourseEnrollmentState.NONE => string.Empty,
                CourseEnrollmentState.ACTIVE => "enrollment_state=" + CourseEnrollmentState.ACTIVE.ToString().ToLower(),
                CourseEnrollmentState.INVITED_OR_PENDING => "enrollment_state=" + CourseEnrollmentState.INVITED_OR_PENDING.ToString().ToLower(),
                CourseEnrollmentState.COMPLETED => "enrollment_state=" + CourseEnrollmentState.COMPLETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown CourseEnrollmentState enum type")
            };

            if (include != null)
            {
                foreach (var item in include)
                {
                    if (item != CourseInclude.NONE &&
                        item != CourseInclude.ALL_COURSES &&
                        item != CourseInclude.PERMISSIONS)
                    {
                        _include += $"include[]=" + item.ToString().ToLower() + "&";
                    }
                }
                _include = _include.Remove(_include.LastIndexOf("&"));
            }

            if (!string.IsNullOrEmpty(_state)) addParams += _state + "&";
            if (!string.IsNullOrEmpty(_enrollment)) addParams += _enrollment + "&";
            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";

            string url = ApiController.GetV1Url("v1/users/" + userId + "/courses", addParams);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Course>>(data.Result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="numUsers"></param>
        /// <param name="type"></param>
        /// <param name="state"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public static async Task<List<User>> ListUsersInCourseAsync(string courseId, string numUsers = null, List<UserEnrollmentType> type = null, List<UserEnrollmentState> state = null, List<UserInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.users

            string _type = null;
            string _state = null;
            string _include = null;
            string _numUsers = null;
            string addParams = null;
            int pages = 1;

            if (!string.IsNullOrEmpty(numUsers) && (int.Parse(numUsers) > 0))
            {
                _numUsers += "per_page=" + numUsers + "&";
                pages = int.Parse(numUsers) / 50 + 1;
            }

            if (type != null)
            {
                foreach (var item in type)
                    _type += "enrollment_type[]=" + item.ToString().ToLower() + "&";
                _type = _type.Remove(_type.LastIndexOf("&"));
            }

            if (state != null)
            {
                foreach (var item in state)
                    _state += "enrollment_state[]=" + item.ToString().ToLower() + "&";
                _state = _state.Remove(_state.LastIndexOf("&"));
            }

            if (include != null)
            {
                foreach (var item in include)
                    _include += "include[]=" + item.ToString().ToLower() + "&";
                _include = _include.Remove(_include.LastIndexOf("&"));
            }

            if (!string.IsNullOrEmpty(_numUsers)) addParams += _numUsers + "&";
            if (!string.IsNullOrEmpty(_type)) addParams += _type + "&";
            if (!string.IsNullOrEmpty(_state)) addParams += _state + "&";
            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";

            List<User> users = new List<User>();

            for (int i = 1; i <= pages; i++)
            {
                string url = ApiController.GetV1Url("v1/courses/" + courseId + "/users", addParams + $"page={i}&");
                using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<User>>(data.Result);
                if (json == null) continue;
                foreach (var item in json)
                    users.Add(item);
            }
            return users;
        }
    }
}
