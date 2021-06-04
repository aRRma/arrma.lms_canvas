using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using arrma.lms_canvas.api_test.api_models;
using arrma.lms_canvas.api_test.api_models.Courses;
using arrma.lms_canvas.api_test.api_models.Users;

namespace arrma.lms_canvas.api_test
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly string server_url = "https://lms.misis.ru:443/api/";
        static readonly string token = "ViNkcfTAwujXMDGHKu3N6Ag0TxYgdi6tQBdezEVBM6WReA7HECDP9h04IIjmGc9o";
        private static readonly string user_id = "23392";
        static async Task Main(string[] args)
        {
            Console.WriteLine("user token: " + token);
            Console.WriteLine("user_id: " + user_id);
            Console.WriteLine("\n");


            Console.WriteLine("Запрашиваем информацию об конкретном пользователе");
            User user = await ShowUserDetails();
            Console.WriteLine($"user_id: {user.id}\nuser_name: {user.name}");
            Console.WriteLine("\n");


            //Console.WriteLine("Запрашиваем список курсов для конкретного пользователя");
            //List<CanvasCourseModel> courses = await ListCoursesForAUser(include: new List<CourseInclude>()
            //    {
            //        CourseInclude.TEACHERS,
            //        CourseInclude.TOTAL_STUDENTS
            //    });
            //foreach (var item in courses)
            //{
            //    Console.WriteLine($"{item.id}\t{item.name}");
            //    Console.WriteLine($"\tВсего студентов: {item.total_students}");
            //    foreach (var teacher in item.teachers) Console.WriteLine($"\tid: {teacher.id}\n\tФИО: {teacher.display_name}");
            //    Console.WriteLine();
            //}
            //Console.WriteLine("\n");


            //Console.WriteLine("Запрашиваем список курсов для текущего пользователя");
            //List<CanvasCourseModel> courses = await ListYourCourses(state: CourseState.AVAILABLE, enrollment: CourseEnrollmentState.NONE, include: new List<CourseInclude>()
            //{
            //    CourseInclude.TEACHERS
            //});
            //foreach (var item in courses)
            //{
            //    Console.WriteLine($"{item.id}\t{item.name}");
            //    Console.WriteLine($"\tВсего студентов: {item.total_students}");
            //    if (item.teachers != null) foreach (var teacher in item.teachers) Console.WriteLine($"\tid: {teacher.id}\n\tФИО: {teacher.display_name}");
            //    Console.WriteLine();
            //}
            //Console.WriteLine("\n");

            Console.WriteLine("Запрашиваем список пользователей на конкретном курсе");
            List<User> courseUsers = await ListUsersInCourse("5031",
                new List<UserEnrollmentType>()
            {
                UserEnrollmentType.STUDENT
            },
                new List<UserEnrollmentState>()
            {
                UserEnrollmentState.ACTIVE
            },
                new List<UserInclude>()
            {
                UserInclude.EMAIL,
                UserInclude.BIO,
                UserInclude.AVATAR_URL,
                UserInclude.ENROLLMENTS
            });
            foreach (var item in courseUsers)
            {
                Console.WriteLine($"id: {item.id}\tФИО: {item.sortable_name}\t Email: {item.email}\t Подразделение: {item.enrollments[0].sis_account_id}");
            }
            Console.WriteLine();

            Console.WriteLine("\n");
            Console.WriteLine("End");
            Console.ReadKey();
        }

        #region api/v1/courses
        static async Task<List<Course>> ListCoursesForAUser(
            string userId = "23392",
            CourseState state = CourseState.AVAILABLE,
            CourseEnrollmentState enrollment = CourseEnrollmentState.ACTIVE,
            List<CourseInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.user_index

            string _state;
            string _enrollment;
            string _include = null;
            string addParams = null;

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

            _state = state switch
            {
                CourseState.NONE => string.Empty,
                CourseState.UNPUBLISHED => "state[]=" + CourseState.UNPUBLISHED.ToString().ToLower(),
                CourseState.AVAILABLE => "state[]=" + CourseState.AVAILABLE.ToString().ToLower(),
                CourseState.COMPLETED => "state[]=" + CourseState.COMPLETED.ToString().ToLower(),
                CourseState.DELETED => "state[]=" + CourseState.DELETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state enum type")
            };

            _enrollment = enrollment switch
            {
                CourseEnrollmentState.NONE => string.Empty,
                CourseEnrollmentState.ACTIVE => "enrollment_state=" + CourseEnrollmentState.ACTIVE.ToString().ToLower(),
                CourseEnrollmentState.INVITED_OR_PENDING => "enrollment_state=" + CourseEnrollmentState.INVITED_OR_PENDING.ToString().ToLower(),
                CourseEnrollmentState.COMPLETED => "enrollment_state=" + CourseEnrollmentState.COMPLETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown enrollment state enum type")
            };

            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";
            if (!string.IsNullOrEmpty(_state)) addParams += _state + "&";
            if (!string.IsNullOrEmpty(_enrollment)) addParams += _enrollment;

            string url = GetApiUrl("v1/users/" + userId + "/courses", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Course>>(data.Result);
        }
        
        static async Task<List<Course>> ListYourCourses(
            CourseEnrollmentRole role = CourseEnrollmentRole.TEACHER,
            CourseState state = CourseState.AVAILABLE,
            CourseEnrollmentState enrollment = CourseEnrollmentState.ACTIVE,
            List<CourseInclude> include = null)
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
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Unknown role enum type")
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

            _state = state switch
            {
                CourseState.NONE => string.Empty,
                CourseState.UNPUBLISHED => "state[]=" + CourseState.UNPUBLISHED.ToString().ToLower(),
                CourseState.AVAILABLE => "state[]=" + CourseState.AVAILABLE.ToString().ToLower(),
                CourseState.COMPLETED => "state[]=" + CourseState.COMPLETED.ToString().ToLower(),
                CourseState.DELETED => "state[]=" + CourseState.DELETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state enum type")
            };

            _enrollment = enrollment switch
            {
                CourseEnrollmentState.NONE => string.Empty,
                CourseEnrollmentState.ACTIVE => "enrollment_state=" + CourseEnrollmentState.ACTIVE.ToString().ToLower(),
                CourseEnrollmentState.INVITED_OR_PENDING => "enrollment_state=" + CourseEnrollmentState.INVITED_OR_PENDING.ToString().ToLower(),
                CourseEnrollmentState.COMPLETED => "enrollment_state=" + CourseEnrollmentState.COMPLETED.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown enrollment state enum type")
            };

            if (!string.IsNullOrEmpty(_role)) addParams += _role + "&";
            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";
            if (!string.IsNullOrEmpty(_state)) addParams += _state + "&";
            if (!string.IsNullOrEmpty(_enrollment)) addParams += _enrollment;

            string url = GetApiUrl("v1/courses/", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Course>>(data.Result);
        }
        
        static async Task<List<User>> ListUsersInCourse(
            string courseId,
            List<UserEnrollmentType> type = null,
            List<UserEnrollmentState> state = null,
            List<UserInclude> include = null)
        {
            // see https://canvas.instructure.com/doc/api/courses.html#method.courses.users

            string _type = null;
            string _state = null;
            string _include = null;
            string addParams = null;

            if (type != null)
            {
                foreach (var item in type)
                {
                    _type += "enrollment_type[]=" + item.ToString().ToLower() + "&";
                }
                _type = _type.Remove(_type.LastIndexOf("&"));
            }

            if (state != null)
            {
                foreach (var item in state)
                {
                    _state += "enrollment_state[]=" + item.ToString().ToLower() + "&";
                }
                _state = _state.Remove(_state.LastIndexOf("&"));
            }

            if (include != null)
            {
                foreach (var item in include)
                {
                    _include += "include[]=" + item.ToString().ToLower() + "&";
                }
                _include = _include.Remove(_include.LastIndexOf("&"));
            }

            if (!string.IsNullOrEmpty(_type)) addParams += _type + "&";
            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";
            if (!string.IsNullOrEmpty(_state)) addParams += _state + "&";

            string url = GetApiUrl("v1/courses/" + courseId + "/users", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(data.Result);
        }
        #endregion

        #region api/v1/users
        static async Task<User> ShowUserDetails(string userId = "23392")
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.users.api_show

            string url = GetApiUrl("v1/users/" + userId);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(data.Result);
        }

        //static async Task<CanvasProfileModel> GetUserProfile(string userId)
        //{

        //}
        #endregion

        static string GetApiUrl(string api_url) => server_url + api_url + "?access_token=" + token;
        static string GetApiUrl(string api_url, string addParams) => server_url + api_url + $"?{addParams}" + $"&access_token={token}";
    }
}