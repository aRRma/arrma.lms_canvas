﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CanvasApiCore.Models.Assignment_Group;
using CanvasApiCore.Models.Assignments;
using CanvasApiCore.Models.Courses;
using CanvasApiCore.Models.Submissions;
using CanvasApiCore.Models.Users;
using CanvasApiCore.Queries;

namespace arrma.lms_canvas.api_test
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly string server_url = "https://lms.misis.ru:443/api/";
        static readonly string token = "ViNkcfTAwujXMDGHKu3N6Ag0TxYgdi6tQBdezEVBM6WReA7HECDP9h04IIjmGc9o";
        private static readonly string user_id = "23392";           //Данильченко
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
            List<StudentSubmissions> studentSubmissions = await SubmissionsQueries.ListSubmissionsForMultiAssignmentsAsync(course_id, new ListMultiSubmParams()
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
            List<Course> course = await CoursesQueries.ListYourCoursesAsync(CourseEnrollmentRole.TEACHER, CourseState.AVAILABLE,
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
                var data = await AssignmentGroupsQueries.ListAssignmentGroupsAsync(course[i].id.ToString(), AssignmentGroupInclude.ASSIGNMENTS);
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
                var data = await CoursesQueries.ListUsersInCourseAsync(course[i].id.ToString(),
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
    }
}