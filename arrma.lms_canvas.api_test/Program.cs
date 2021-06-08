using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using arrma.lms_canvas.api_test.api_models.Assignment_Group;
using arrma.lms_canvas.api_test.api_models.Assignments;
using arrma.lms_canvas.api_test.api_models.Courses;
using arrma.lms_canvas.api_test.api_models.Submissions;
using arrma.lms_canvas.api_test.api_models.Submissions.Query_params_ojb;
using arrma.lms_canvas.api_test.api_models.Users;

namespace arrma.lms_canvas.api_test
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly string server_url = "https://lms.misis.ru:443/api/";
        static readonly string token = "ViNkcfTAwujXMDGHKu3N6Ag0TxYgdi6tQBdezEVBM6WReA7HECDP9h04IIjmGc9o";
        private static readonly string user_id = "23392";           //данильченко
        private static readonly string course_id = "11527";         //ООП Бивт-20
        private static readonly string assignment_id = "115645";    //ЛР№1_Отч
        private static readonly string student_id = "31411";        //Дмитрий Генкель


        static async Task Main(string[] args)
        {
            Console.WriteLine("user token: " + token);
            Console.WriteLine("user_id: " + user_id);
            Console.WriteLine("\n");

            #region test_methods
            //Console.WriteLine("Запрашиваем информацию об конкретном пользователе");
            //User user = await ShowUserDetails();
            //Console.WriteLine($"user_id: {user.id}\nuser_name: {user.name}");
            //Console.WriteLine("\n");


            //Console.WriteLine("Запрашиваем список курсов для конкретного пользователя");
            //List<Course> courses_0 = await ListCoursesForAUser(include: new List<CourseInclude>()
            //    {
            //        CourseInclude.TEACHERS,
            //        CourseInclude.TOTAL_STUDENTS
            //    });
            //foreach (var item in courses_0)
            //{
            //    Console.WriteLine($"{item.id}\t{item.name}");
            //    Console.WriteLine($"\tВсего студентов: {item.total_students}");
            //    Console.WriteLine($"\tПреподаватели на курсе:");
            //    foreach (var teacher in item.teachers) Console.WriteLine($"\tid: {teacher.id}\tФИО: {teacher.display_name}");
            //    Console.WriteLine();
            //}
            //Console.WriteLine("\n");


            //Console.WriteLine("Запрашиваем список курсов для текущего пользователя");
            //List<Course> courses_1 = await ListYourCourses(state: CourseState.AVAILABLE, enrollment: CourseEnrollmentState.NONE, include: new List<CourseInclude>()
            //{
            //    CourseInclude.TEACHERS,
            //    CourseInclude.TOTAL_STUDENTS
            //});
            //foreach (var item in courses_1)
            //{
            //    Console.WriteLine($"{item.id}\t{item.name}");
            //    Console.WriteLine($"\tВсего студентов: {item.total_students}");
            //    Console.WriteLine($"\tПреподаватели на курсе:");
            //    if (item.teachers != null) foreach (var teacher in item.teachers) Console.WriteLine($"\tid: {teacher.id}\tФИО: {teacher.display_name}");
            //    Console.WriteLine();
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("Запрашиваем список пользователей на конкретном курсе");
            //List<User> courseUsers = await ListUsersInCourse("5031",
            //    new List<UserEnrollmentType>()
            //{
            //    UserEnrollmentType.STUDENT
            //},
            //    new List<UserEnrollmentState>()
            //{
            //    UserEnrollmentState.ACTIVE
            //},
            //    new List<UserInclude>()
            //{
            //    UserInclude.EMAIL,
            //    UserInclude.BIO,
            //    UserInclude.AVATAR_URL,
            //    UserInclude.ENROLLMENTS
            //});
            //foreach (var item in courseUsers)
            //{
            //    Console.WriteLine($"id: {item.id}\tФИО: {item.sortable_name}\t Email: {item.email}\t Подразделение: {item.enrollments[0].sis_account_id}");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Запрашиваем задания для курса");
            //List<Assignment> assignments = await ListAssignments(courseId: "11527",
            //    bucket: AssignmentBucket.PAST,
            //    orderBy: AssignmentOrderBy.NAME,
            //    include: new List<AssignmentInclude>()
            //    {
            //        AssignmentInclude.ALL_DATES
            //    });
            //foreach (var item in assignments)
            //{
            //    Console.WriteLine($"{item.id}\t{item.name}\t");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Запрашиваем группы заданий с массивом самих заданий");
            //List<AssignmentGroup> listGroup = await ListAssignmentGroups("11527", AssignmentGroupInclude.ASSIGNMENTS);
            //foreach (var item in listGroup)
            //{
            //    Console.WriteLine($"Id группы: {item.id}\tНазвание группы: {item.name}");
            //    if (item.assignments != null)
            //        foreach (var assignment in item.assignments)
            //            Console.WriteLine($"\t\tId задания: {assignment.id}\tНазвание задания: {assignment.name}");
            //}
            //Console.WriteLine();

            Console.WriteLine("Запрашиваем массив представлений заданий для n-го количества студентов");
            List<StudentSubmissions> studentSubmissions = await ListSubmissionsForMultiAssignments(course_id, new ListMultiSubmQueryAddParams()
            {
                student_ids = new[] { student_id },
                grouped = true,
                workflow_state = SubmissionWorkflowState.GRADED,
                include = new List<SubmissionInclude>() { SubmissionInclude.ASSIGNMENT, SubmissionInclude.USER }
            });
            foreach (var item in studentSubmissions)
            {
                Console.WriteLine($"Студент Id: {item.user_id}\nФИО: {item.submissions[0].user.short_name}\nSis: {item.sis_user_id}");
                foreach (var submissions in item.submissions)
                    Console.WriteLine($"\t\tId задания: {submissions?.assignment_id}\tНазвание: {submissions.assignment?.name}\tСтатус: {submissions?.workflow_state}\tОценка: {(submissions?.grade == null ? "не известно" : submissions?.grade)}\tВовремя: {!submissions?.late}\tПроверил: {submissions?.grader_id}");
            }
            Console.WriteLine();

            //Console.WriteLine("Запрашиваем представление задания для конкретного пользователя");
            //Submission submission = await GetSingleSubmission("11527", "115637", "32081", new List<SubmissionInclude>
            //{
            //    SubmissionInclude.SUBMISSION_HISTORY,
            //    SubmissionInclude.SUBMISSION_COMMENTS,
            //    SubmissionInclude.USER

            //});
            //Console.WriteLine($"User Id: {(await GetUserProfile(submission.user_id.ToString())).sortable_name}\tAssignment Id: {submission.assignment_id}\tGrader Id: {(await ShowUserDetails(submission.grader_id.ToString())).short_name}");
            //Console.WriteLine($"\tWorkflow: {submission.workflow_state}\tGrade: {submission.grade}\tGrade at: {submission.graded_at.Value.ToString("F")}\tAttempt: {submission.attempt}");
            //Console.WriteLine();
            #endregion

            #region List assignments for all students at course and show who graded submission

            //await ListAllMyCoursesAndSubmissions("23392");

            #endregion

            Console.WriteLine("\n");
            Console.WriteLine("End");
            Console.ReadKey();
        }

        #region Some scripts

        static async Task ListAllMyCoursesAndSubmissions(string userId)
        {
            List<Course> course = await ListYourCourses(CourseEnrollmentRole.TEACHER, CourseState.AVAILABLE,
                CourseEnrollmentState.ACTIVE, new List<CourseInclude>
                {
                    CourseInclude.TOTAL_STUDENTS,
                    CourseInclude.NEEDS_GRADING_COUNT,
                    CourseInclude.TEACHERS,

                });
            course.Remove(course.Find(x => x.id == 7540));

            foreach (var item in course.OrderBy(x => x.total_students))
            {
                if (item.id == 7540) continue;
                Console.Write($"Название курса: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{item.course_code} {item.name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"ID курса: {item.id}\tКурс публичный: {(item.is_public == true ? "да" : "нет")}");
                Console.Write($"Всего студентов на курсе: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{item.total_students}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Нужно проверить заданий: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{item.needs_grading_count}\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Преподаватели на курсе:");
                foreach (var teacher in item.teachers.OrderBy(x => x.id))
                {
                    Console.Write($"\tID: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{teacher.id}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"ФИО: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{teacher.display_name.ToUpper()}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Запросили курсы...\n\n");

            List<AssignmentGroup> assignmentsGroup = new List<AssignmentGroup>();

            for (int i = 0; i < course.Count; i++)
            {
                var data = await ListAssignmentGroups(course[i].id.ToString(), AssignmentGroupInclude.ASSIGNMENTS);
                Console.Write($"Название курса: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{course[i].course_code} {course[i].name}");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var item in data.OrderBy(x => x.position))
                {
                    assignmentsGroup.Add(item);
                    Console.Write($"ID группы зад.: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{item.id}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Название группы зад.: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{item.name}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Задания:");
                    foreach (var assignment in item.assignments.OrderBy(x => x.position))
                    {
                        Console.Write($"\tID: {assignment.id}\tНазвание: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{assignment.name}\t\t");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"Нужно оценит: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{assignment.needs_grading_count}\t\t");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Опубликовано: {(assignment.published == true ? "Да" : "Нет")}\tДата создания: {assignment.created_at.Value.ToString("g")}");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Запросили задания для курса...\n\n");

            List<User> courseSrudens = new List<User>();

            for (int i = 0; i < course.Count; i++)
            {
                var data = await ListUsersInCourse(course[i].id.ToString(),
                    course[i].total_students?.ToString(),
                    new List<UserEnrollmentType> { UserEnrollmentType.STUDENT },
                    new List<UserEnrollmentState> { UserEnrollmentState.ACTIVE },
                    new List<UserInclude> { UserInclude.CURRENT_GRADING_PERIOD_SCORES, UserInclude.EMAIL });
                Console.Write($"Название курса: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{course[i].course_code} {course[i].name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Студентов на курсе ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{course[i].total_students}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($":");
                Console.Write($"Активных студентов на курсе ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{data.Count}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($":");
                foreach (var user in data.OrderBy(x => x.id))
                {
                    Console.Write($"\tID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{user.id}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"ФИО: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{user.short_name.ToUpper()}\t\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Email: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{user.email}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Запросили студентов на курсе...\n\n");

            ////////////////////////////////////////////////////////////

            Console.WriteLine($"Запросили представления заданий...\n\n");
        }

        #endregion

        #region api/v1/assignment_groups
        static async Task<List<AssignmentGroup>> ListAssignmentGroups(string courseId, AssignmentGroupInclude include = AssignmentGroupInclude.NONE)
        {
            string _include;
            string addParams = null;

            _include = include switch
            {
                AssignmentGroupInclude.NONE => string.Empty,
                AssignmentGroupInclude.ASSIGNMENTS => "include=" + AssignmentGroupInclude.ASSIGNMENTS.ToString().ToLower(),
                _ => throw new ArgumentOutOfRangeException(nameof(include), include, "Unknown AssignmentGroupInclude enum type")
            };

            if (!string.IsNullOrEmpty(_include)) addParams += _include + "&";

            string url = GetApiUrl("v1/courses/" + courseId + "/assignment_groups", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AssignmentGroup>>(data.Result);
        }
        #endregion

        #region api/v1/assignments
        static async Task<List<Assignment>> ListAssignments(string courseId, string searchTerm = null, AssignmentBucket bucket = AssignmentBucket.UPCOMING, AssignmentOrderBy orderBy = AssignmentOrderBy.NAME, List<AssignmentInclude> include = null)
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

            string url = GetApiUrl("v1/courses/" + courseId + "/assignments", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Assignment>>(data.Result);
        }
        #endregion

        #region api/v1/courses
        static async Task<List<Course>> ListYourCourses(CourseEnrollmentRole role = CourseEnrollmentRole.TEACHER, CourseState state = CourseState.AVAILABLE, CourseEnrollmentState enrollment = CourseEnrollmentState.ACTIVE, List<CourseInclude> include = null)
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

            string url = GetApiUrl("v1/courses/", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Course>>(data.Result);
        }
        static async Task<List<Course>> ListCoursesForAUser(string userId = "23392", CourseState state = CourseState.AVAILABLE, CourseEnrollmentState enrollment = CourseEnrollmentState.ACTIVE, List<CourseInclude> include = null)
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

            string url = GetApiUrl("v1/users/" + userId + "/courses", addParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Course>>(data.Result);
        }
        static async Task<List<User>> ListUsersInCourse(string courseId, string numUsers = null, List<UserEnrollmentType> type = null, List<UserEnrollmentState> state = null, List<UserInclude> include = null)
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
                string url = GetApiUrl("v1/courses/" + courseId + "/users", addParams + $"page={i}&");
                using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<User>>(data.Result);
                if (json == null) continue;
                foreach (var item in json)
                    users.Add(item);
            }
            return users;
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
        static async Task<UserProfile> GetUserProfile(string userId = "23392")
        {
            string url = GetApiUrl("v1/users/" + userId + "/profile");
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserProfile>(data.Result);
        }
        #endregion

        #region api/v1/submissions
        /// <summary>
        /// Запросить представления для списка заданий и для n-го числа студентов
        /// </summary>
        /// <param name="courseId">ID курса</param>
        /// <param name="addParams">Обьект дополнительных параметров для запроса</param>
        /// <returns></returns>
        static async Task<List<StudentSubmissions>> ListSubmissionsForMultiAssignments(string courseId, ListMultiSubmQueryAddParams addParams)
        {
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

            string url = GetApiUrl("v1/courses/" + courseId + "/students/submissions", _queryParams);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<StudentSubmissions>>(data.Result);
        }
        static async Task<Submission> GetSingleSubmission(string courseId, string assignmentId, string userId, List<SubmissionInclude> include = null)
        {
            string _include = null;

            if (include != null)
                foreach (var item in include)
                    _include += "include[]=" + item.ToString().ToLower() + "&";

            string url = GetApiUrl("v1/courses/" + courseId + "/assignments/" + assignmentId + "/submissions/" + userId, _include);
            using var data = (await httpClient.GetAsync(url)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Submission>(data.Result);
        }
        #endregion

        static string GetApiUrl(string api_url) => server_url + api_url + "?access_token=" + token;
        static string GetApiUrl(string api_url, string addParams) => server_url + api_url + $"?{addParams}" + $"access_token={token}";
    }
}