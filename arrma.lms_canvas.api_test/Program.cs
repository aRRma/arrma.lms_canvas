using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CanvasApiCore.Models.Assignment_Group;
using CanvasApiCore.Models.Assignments;
using CanvasApiCore.Models.Courses;
using CanvasApiCore.Models.Query_objects;
using CanvasApiCore.Models.Submissions;
using CanvasApiCore.Models.Users;
using CanvasApiCore.Queries;

namespace arrma.lms_canvas.api_test
{
    class Program
    {
        static readonly string server_url = "https://lms.misis.ru:443/api/";
        static readonly string token = "ViNkcfTAwujXMDGHKu3N6Ag0TxYgdi6tQBdezEVBM6WReA7HECDP9h04IIjmGc9o";
        //тестовые данные 
        private static readonly string test_user_id = "23392";           //Данильченко
        private static readonly string test_course_id = "11527";         //ООП Бивт-20
        private static readonly string test_assignment_id = "115645";    //ЛР№1_Отч
        private static readonly string test_student_id = "31411";        //Дмитрий Генкель
        //кэш данных
        private static readonly Dictionary<string, Course> cashe_courses = new Dictionary<string, Course>();
        private static readonly Dictionary<string, UserDisplay> cashe_teachers = new Dictionary<string, UserDisplay>();
        private static readonly Dictionary<string, AssignmentGroup> cashe_assignmentGroups = new Dictionary<string, AssignmentGroup>();
        private static readonly Dictionary<string, Assignment> cashe_assignments = new Dictionary<string, Assignment>();
        private static readonly Dictionary<string, User> cashe_users = new Dictionary<string, User>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("user token: " + token);
            Console.WriteLine("user_id: " + test_user_id);
            Console.WriteLine("\n");

            #region List assignments for all students at course and show who graded submission
            await ListAllMyCoursesAndSubmissions();
            #endregion

            Console.WriteLine("\n");
            Console.WriteLine("End");
            Console.ReadKey();
        }

        #region Some scripts
        /// <summary>
        /// Метод запрашивает и отображает все актуальные курсы для текущего пользователя. Все группы и сами задания. Список всех активных студентов на курсах. Представления заданий для каждого студента.
        /// </summary>
        /// <remarks>Сейчас представления заданий выводится только для 2 студентов с каждого курса</remarks>
        /// <returns></returns>
        static async Task ListAllMyCoursesAndSubmissions()
        {
            List<Course> course = await CoursesQueries.ListYourCoursesAsync(new ListYourCoursesParams()
            {
                include = new List<CourseInclude>() { CourseInclude.TOTAL_STUDENTS, CourseInclude.NEEDS_GRADING_COUNT, CourseInclude.TEACHERS },
                enrollment_type = CourseEnrollmentType.TEACHER,
                state = new List<CourseState>() { CourseState.AVAILABLE }
            });
            course.Remove(course.Find(x => x.id == 7540));

            foreach (var item in course.OrderBy(x => x.total_students))
            {
                course.Remove(course.Find(x => x.start_at < new DateTime(2021, 1, 1)));
                if (item.id == 7540) continue;
                if (!cashe_courses.ContainsKey(item.id?.ToString()))
                    cashe_courses.Add(item.id?.ToString(), item);
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
                    if (!cashe_teachers.ContainsKey(teacher?.id.ToString()))
                        cashe_teachers.Add(teacher?.id.ToString(), teacher);
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

            for (int i = 0; i < course.Count; i++)
            {
                var data = await AssignmentGroupsQueries.ListAssignmentGroupsAsync(course[i].id.ToString(), AssignmentGroupInclude.ASSIGNMENTS);
                Console.Write($"Название курса: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{course[i].course_code} {course[i].name}");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var item in data.OrderBy(x => x.position))
                {
                    if (!cashe_assignmentGroups.ContainsKey(item.id.ToString()))
                        cashe_assignmentGroups.Add(item.id.ToString(), item);
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
                        if (!cashe_assignments.ContainsKey(assignment.id.ToString()))
                            cashe_assignments.Add(assignment.id.ToString(), assignment);
                        Console.Write($"\tID: {assignment.id}\tНазвание: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{assignment.name}\t\t");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"Нужно оценить: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{assignment.needs_grading_count}\t\t");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Опубликовано: {(assignment.published == true ? "Да" : "Нет")}\tДата создания: {assignment.created_at.Value.ToString("g")}");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Запросили задания для курса...\n\n");

            Dictionary<string, List<User>> courseStudens = new Dictionary<string, List<User>>();

            for (int i = 0; i < course.Count; i++)
            {
                var data = await CoursesQueries.ListUsersInCourseAsync(course[i].id.ToString(), new ListUsersInCourseParams()
                {
                    include = new List<UserInclude>() { UserInclude.CURRENT_GRADING_PERIOD_SCORES, UserInclude.EMAIL },
                    enrollment_state = new List<UserEnrollmentState>() { UserEnrollmentState.ACTIVE, UserEnrollmentState.INVITED },
                    enrollment_type = UserEnrollmentType.STUDENT,
                    number_students = course[i].total_students
                });
                List<User> tempUsers = new List<User>();
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
                    tempUsers.Add(user);
                    if (!cashe_users.ContainsKey(user.id.ToString()))
                        cashe_users.Add(user.id.ToString(), user);
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
                courseStudens.Add(course[i].id.ToString(), tempUsers);
                Console.WriteLine();
            }
            Console.WriteLine($"Запросили студентов на курсе...\n\n");

            foreach (var item in courseStudens)
            {
                for (int i = 0; i < 2; i++)
                {
                    var submissions = await SubmissionsQueries.ListSubmissionsForMultiAssignmentsAsync(item.Key,
                        new ListMultiSubmParams()
                        {
                            include = new List<SubmissionInclude>() { SubmissionInclude.USER, SubmissionInclude.ASSIGNMENT, SubmissionInclude.SUBMISSION_HISTORY, SubmissionInclude.COURSE },
                            grouped = true,
                            workflow_state = SubmissionWorkflowState.GRADED,
                            student_ids = new[] { item.Value[i].id.ToString() }
                        });
                    try
                    {
                        foreach (var grSubm in submissions)
                        {
                            Console.Write($"ID студента: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{grSubm.user_id}");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (grSubm?.submissions.Length > 0)
                            {
                                Console.Write($"ФИО: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{grSubm.submissions[0].user.short_name}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"Email: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{grSubm.submissions[0].user.sis_user_id}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"Курс: ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"{grSubm.submissions[0].course.name}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            foreach (var subm in grSubm.submissions)
                            {
                                Console.Write($"\tID ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"{subm?.assignment?.id}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" : ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{subm?.assignment?.name}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"\tДоступно с ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"{subm?.assignment?.unlock_at?.ToString("d")}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($" до ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{subm?.assignment?.lock_at?.ToString("d")}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"\tСрок сдачи ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"{subm?.assignment?.due_at?.ToString("d")}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"\t\t");
                                foreach (var submHist in subm.submission_history)
                                {
                                    if (submHist.attachments != null)
                                    {
                                        foreach (var attach in submHist.attachments)
                                        {
                                            Console.Write($"\t\t\tФайл: ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write($"{attach?.display_name}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tФормат: ");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write($"{attach?.mime_class}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tЗагружен: ");
                                            if (attach?.created_at > subm?.assignment?.due_at)
                                                Console.ForegroundColor = ConsoleColor.Red;
                                            else
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write($"{attach?.created_at?.ToString("G")}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tСост.: ");
                                            if (submHist?.workflow_state != null)
                                            {
                                                SubmissionWorkflowState workflow;

                                                if (Enum.TryParse<SubmissionWorkflowState>(submHist?.workflow_state,
                                                    true, out workflow))
                                                {
                                                    switch (workflow)
                                                    {
                                                        case SubmissionWorkflowState.GRADED:
                                                        case SubmissionWorkflowState.COMPLETE:
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            break;
                                                        case SubmissionWorkflowState.SUBMITTED:
                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                            break;
                                                        default:
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            break;
                                                    }
                                                }
                                            }
                                            Console.Write($"{submHist?.workflow_state}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tОценка: ");
                                            if (submHist?.grade != null)
                                            {
                                                SubmissionGrade grade;

                                                if (Enum.TryParse<SubmissionGrade>(submHist?.grade, true, out grade))
                                                    switch (grade)
                                                    {
                                                        case SubmissionGrade.COMPLETE:
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            break;
                                                        case SubmissionGrade.INCOMPLETE:
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            break;
                                                        default:
                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                            break;
                                                    }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                }
                                            }
                                            Console.Write($"{submHist?.grade}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tБаллы: ");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($"{submHist?.score}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tПопыток: ");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write($"{submHist?.attempt}");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.Write($"\tПроверил: ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write($"{(submHist.grader_id != null ? cashe_teachers[submHist.grader_id.ToString()].display_name : "-")} {submHist.graded_at?.ToString("g")}");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                        }

                                    }
                                    else
                                    {
                                        Console.Write($"\tСост.: ");
                                        if (submHist?.workflow_state != null)
                                        {
                                            SubmissionWorkflowState workflow;

                                            if (Enum.TryParse<SubmissionWorkflowState>(submHist?.workflow_state,
                                                true, out workflow))
                                            {
                                                switch (workflow)
                                                {
                                                    case SubmissionWorkflowState.GRADED:
                                                    case SubmissionWorkflowState.COMPLETE:
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        break;
                                                    case SubmissionWorkflowState.SUBMITTED:
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        break;
                                                    default:
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        break;
                                                }
                                            }
                                        }
                                        Console.Write($"{submHist?.workflow_state}");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.Write($"\tОценка: ");
                                        if (submHist?.grade != null)
                                        {
                                            SubmissionGrade grade;

                                            if (Enum.TryParse<SubmissionGrade>(submHist?.grade, true, out grade))
                                                switch (grade)
                                                {
                                                    case SubmissionGrade.COMPLETE:
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        break;
                                                    case SubmissionGrade.INCOMPLETE:
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        break;
                                                    default:
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        break;
                                                }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            }
                                        }
                                        Console.Write($"{submHist?.grade}");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.Write($"\tБаллы: ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write($"{submHist?.score}");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.Write($"\tПопыток: ");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write($"{submHist?.attempt}");
                                        Console.ForegroundColor = ConsoleColor.White;

                                        Console.Write($"\tПроверил: ");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        if (submHist.grader_id != null && cashe_teachers.ContainsKey(submHist.grader_id.ToString()))
                                            Console.Write($"{cashe_teachers[submHist.grader_id.ToString()].display_name} {submHist.graded_at?.ToString("g")}");
                                        else
                                            Console.Write($"- {submHist.graded_at?.ToString("g")}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine();
                                    }
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            Console.WriteLine($"Запросили представления заданий...\n\n");
        }
        #endregion
    }
}