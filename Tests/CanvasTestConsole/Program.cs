using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CanvasApiCore.Models;
using CanvasApiCore.Queries;
using CanvasEFCore;
using CanvasEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CanvasTestConsole
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
        private static readonly Dictionary<string, CourseJson> cashe_courses = new Dictionary<string, CourseJson>();
        private static readonly Dictionary<string, UserDisplayJson> cashe_teachers = new Dictionary<string, UserDisplayJson>();
        private static readonly Dictionary<string, AssignmentGroupJson> cashe_assignmentGroups = new Dictionary<string, AssignmentGroupJson>();
        private static readonly Dictionary<string, AssignmentJson> cashe_assignments = new Dictionary<string, AssignmentJson>();
        private static readonly Dictionary<string, UserJson> cashe_students = new Dictionary<string, UserJson>();
        //контекст базы
        private static readonly ApplicationDbContext db = new ApplicationDbContext();
        //форматтер текста
        private static TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        static async Task Main(string[] args)
        {
            Console.WriteLine("user token: " + token);
            Console.WriteLine("user_id: " + test_user_id);
            Console.WriteLine("\n");

            //await ListAllCourseData();
            await FillCanvasDbForUser();

            Console.WriteLine("\n");
            Console.WriteLine("End");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод запрашивает и отображает все актуальные курсы для текущего пользователя. Все группы и сами задания. Список всех активных студентов на курсах. Представления заданий для каждого студента.
        /// </summary>
        /// <remarks>Сейчас представления заданий выводится только для 2 студентов с каждого курса</remarks>
        /// <returns></returns>
        static async Task ListAllCourseData()
        {
            List<CourseJson> course = await CoursesQueries.ListYourCoursesAsync(new ListYourCoursesParams()
            {
                include = new List<CourseInclude>() { CourseInclude.TOTAL_STUDENTS, CourseInclude.NEEDS_GRADING_COUNT, CourseInclude.TEACHERS },
                enrollment_type = CourseUserEnrollmentType.TEACHER,
                state = new List<CourseState>() { CourseState.AVAILABLE }
            });
            course.Remove(course.Find(x => x.id == 7540));
            course.RemoveAll(x => x.start_at < new DateTime(2021, 1, 1));

            foreach (var item in course.OrderBy(x => x.id))
            {
                if (!cashe_courses.ContainsKey(item.id.ToString()))
                    cashe_courses.Add(item.id.ToString(), item);

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

            Dictionary<string, List<UserJson>> courseStudens = new Dictionary<string, List<UserJson>>();

            for (int i = 0; i < course.Count; i++)
            {
                var data = await CoursesQueries.ListUsersInCourseAsync(course[i].id.ToString(), new ListUsersInCourseParams()
                {
                    include = new List<UserInclude>() { UserInclude.CURRENT_GRADING_PERIOD_SCORES, UserInclude.EMAIL },
                    enrollment_state = new List<UserEnrollmentState>() { UserEnrollmentState.ACTIVE, UserEnrollmentState.INVITED },
                    enrollment_type = UserEnrollmentType.STUDENT,
                    number_students = course[i].total_students
                });
                List<UserJson> tempUsers = new List<UserJson>();
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
                    if (!cashe_students.ContainsKey(user.id.ToString()))
                        cashe_students.Add(user.id.ToString(), user);
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
        /// <summary>
        /// Метод заполняет базу данных canvas.db
        /// </summary>
        /// <returns></returns>
        static async Task FillCanvasDbOld()
        {
            // пишем в бд
            // заполняем таблицу Преподавателей из кэша
            foreach (var c_t in cashe_teachers.OrderBy(x => x.Value.id))
            {
                if (db.Teachers.Count(x => x.Lms_id.Equals(c_t.Value.id)) <= 0)
                {
                    var tp = await UsersQueries.GetUserProfileAsync(c_t.Value.id.ToString());
                    db.Teachers.Add(new LmsTeacher()
                    {
                        Lms_id = (int)tp.id,
                        Email = tp.primary_email,
                        Login_id = tp.login_id,
                        Name = textInfo.ToTitleCase(tp.sortable_name.Split(',')[1].ToLower()),
                        Surname = textInfo.ToTitleCase(tp.sortable_name.Split(',')[0].ToLower()),
                        Role = textInfo.ToTitleCase(CourseUserEnrollmentType.TEACHER.ToString().ToLower())
                    });
                }
            }
            await db.SaveChangesAsync();
            // заполняем таблицу Студентов из кэша
            foreach (var c_s in cashe_students.OrderBy(x => x.Value.id))
            {
                if (db.Students.Count(x => x.Lms_id.Equals(c_s.Value.id)) <= 0)
                {
                    db.Students.Add(new LmsStudent()
                    {
                        Lms_id = (int)c_s.Value.id,
                        Email = c_s.Value.email,
                        Login_id = c_s.Value.login_id,
                        Name = textInfo.ToTitleCase(c_s.Value.sortable_name.Split(',')[1].ToLower()),
                        Surname = textInfo.ToTitleCase(c_s.Value.sortable_name.Split(',')[0].ToLower()),
                        Role = textInfo.ToTitleCase(CourseUserEnrollmentType.STUDENT.ToString().ToLower())
                    });
                }
            }
            await db.SaveChangesAsync();

            foreach (var c_с in cashe_courses)
            {
                // заполняем таблицу Курсов из кэша
                if (db.Courses.Count(x => x.Lms_id.Equals(c_с.Value.id)) <= 0)
                    db.Courses.Add(new LmsCourse()
                    {
                        Lms_id = (int)c_с.Value.id,
                        Name = c_с.Value.name,
                        Course_code = c_с.Value.course_code,
                        Total_students = c_с.Value.total_students,
                        Total_teachers = c_с.Value.teachers?.Length,
                        Workflow_state = c_с.Value.workflow_state.ToString(),
                        Start_at = c_с.Value.start_at,
                        End_at = c_с.Value.end_at
                    });

                foreach (var db_c in db.Courses
                    .Include(x => x.Teachers)
                    .Include(x => x.Students)
                    .Include(x => x.AssignmentGroups)
                    .Where(x => x.Lms_id.Equals(c_с.Value.id)))
                {
                    // добавляем преподавателей к курсам
                    foreach (var c_ct in c_с.Value.teachers)
                        if (db_c.Teachers.Count(x => x.Lms_id.Equals(c_ct.id)) <= 0)
                        {
                            db_c.Teachers.Add(db.Teachers.FirstOrDefault(x => x.Lms_id.Equals(c_ct.id)));
                            await db.SaveChangesAsync();
                        }

                    // добавляем студентов к курсам
                    var data = await CoursesQueries.ListUsersInCourseAsync(db_c.Lms_id.ToString(), new ListUsersInCourseParams()
                    {
                        include = new List<UserInclude>() { UserInclude.CURRENT_GRADING_PERIOD_SCORES, UserInclude.EMAIL },
                        enrollment_state = new List<UserEnrollmentState>() { UserEnrollmentState.ACTIVE, UserEnrollmentState.INVITED },
                        enrollment_type = UserEnrollmentType.STUDENT,
                        number_students = db_c.Total_students
                    });
                    foreach (var u in data)
                    {
                        if (db_c.Students.Count(x => x.Lms_id.Equals(u.id)) <= 0)
                        {
                            db_c.Students.Add(db.Students.FirstOrDefault(x => x.Lms_id.Equals(u.id)));
                            await db.SaveChangesAsync();
                        }
                    }

                    // заполняем группы заданий и сами задания
                    var asGr = await AssignmentGroupsQueries.ListAssignmentGroupsAsync(db_c.Lms_id.ToString(), AssignmentGroupInclude.ASSIGNMENTS);
                    foreach (var asGrItem in asGr)
                    {
                        var gr = new LmsAssignmentGroup()
                        {
                            Lms_id = (int)asGrItem.id,
                            Name = asGrItem.name,
                            Group_weight = asGrItem.group_weight,
                            Position = asGrItem.position
                        };
                        // добавляем группу заданий в таблицу
                        if (db.AssignmentGroups.Count(x => x.Lms_id.Equals(asGrItem.id)) <= 0)
                            db.AssignmentGroups.Add(gr);

                        // добавляем группу заданий к курсу
                        if (db_c.AssignmentGroups.Count(x => x.Lms_id.Equals(asGrItem.id)) <= 0)
                        {
                            db_c.AssignmentGroups.Add(gr);
                            foreach (var asItem in asGrItem.assignments)
                            {
                                var assignment = new LmsAssignment()
                                {
                                    Lms_id = (int)asItem.id,
                                    Name = asItem.name,
                                    Created_at = asItem.created_at,
                                    Description = asItem.description,
                                    Due_at = asItem.due_at,
                                    Lock_at = asItem.lock_at,
                                    Needs_grading_count = asItem.needs_grading_count,
                                    Position = asItem.position,
                                    Unlock_at = asItem.unlock_at,
                                    Updated_at = asItem.updated_at

                                };
                                // добавляем задание в таблицу
                                if (db.Assignments.Count(x => x.Lms_id.Equals(asItem.id)) <= 0)
                                    db.Assignments.Add(assignment);

                                // добавляем задание в группу заданий
                                if (db_c.AssignmentGroups.FirstOrDefault(x => x.Lms_id.Equals(asGrItem.id)).Assignments.Count(x => x.Lms_id.Equals(asItem.id)) <= 0)
                                    db_c.AssignmentGroups.FirstOrDefault(x => x.Lms_id.Equals(asGrItem.id)).Assignments.Add(assignment);

                                await db.SaveChangesAsync();
                            }
                        }
                    }

                    var submissions = await SubmissionsQueries.ListSubmissionsForMultiAssignmentsAsync(db_c.Lms_id.ToString(),
                        new ListMultiSubmParams()
                        {
                            include = new List<SubmissionInclude>() { SubmissionInclude.USER, SubmissionInclude.ASSIGNMENT, SubmissionInclude.SUBMISSION_HISTORY, SubmissionInclude.COURSE },
                            grouped = true,
                            workflow_state = SubmissionWorkflowState.GRADED,
                            student_ids = db_c.Students.Select(x => x.Lms_id.ToString()).ToArray()
                        });
                }
            }

            await db.SaveChangesAsync();
        }
        static async Task FillCanvasDbForUser()
        {
            var listCourses = await CoursesQueries.ListYourCoursesAsync(new ListYourCoursesParams()
            {
                enrollment_state = CourseUserEnrollmentState.ACTIVE,
                enrollment_type = CourseUserEnrollmentType.TEACHER,
                include = new List<CourseInclude>()
                {
                    CourseInclude.TEACHERS,
                    CourseInclude.NEEDS_GRADING_COUNT,
                    CourseInclude.TOTAL_STUDENTS
                }
            });
            //заполнили таблицу курсов и преподавателей. добавили преподавателей к курсу
            foreach (var listCoursesItem in listCourses.OrderBy(x => x.id))
            {
                var lmsCourse = new LmsCourse()
                {
                    Lms_id = listCoursesItem.id,
                    Name = listCoursesItem.name,
                    Course_code = listCoursesItem.course_code,
                    Total_students = listCoursesItem.total_students,
                    Total_teachers = listCoursesItem.teachers?.Length,
                    Needs_grading_count = listCoursesItem.needs_grading_count,
                    Workflow_state = listCoursesItem.workflow_state.ToString(),
                    Start_at = listCoursesItem.start_at,
                    End_at = listCoursesItem.end_at
                };

                if (db.Courses.Count(x => x.Lms_id.Equals(lmsCourse.Lms_id)) <= 0)
                {
                    db.Courses.Add(lmsCourse);
                    await db.SaveChangesAsync();
                }

                if (listCoursesItem.teachers != null)
                    foreach (var teachersItem in listCoursesItem.teachers)
                    {
                        var test = teachersItem.display_name.Split(' ');
                        var lmsTeacher = new LmsTeacher()
                        {
                            Lms_id = teachersItem.id,
                            Name = textInfo.ToTitleCase(teachersItem.display_name.Split(' ')[0].ToLower()),
                            Surname = textInfo.ToTitleCase(teachersItem.display_name.Split(' ').Length > 2
                                ? teachersItem.display_name.Split(' ')[2].ToLower()
                                : string.Empty),
                            Patronymic = textInfo.ToTitleCase(teachersItem.display_name.Split(' ').Length > 1
                                ? teachersItem.display_name.Split(' ')[1].ToLower()
                                : string.Empty),
                            Role = textInfo.ToTitleCase(CourseUserEnrollmentType.TEACHER.ToString().ToLower())
                        };

                        if (db.Teachers.Count(x => x.Lms_id.Equals(lmsTeacher.Lms_id)) <= 0)
                        {
                            db.Teachers.Add(lmsTeacher);
                            await db.SaveChangesAsync();
                        }

                        if (db.Courses
                            .Include(x => x.Teachers)
                            .FirstOrDefault(x => x.Lms_id.Equals(listCoursesItem.id)).Teachers
                            .Count(x => x.Lms_id.Equals(lmsTeacher.Lms_id)) <= 0)
                        {
                            db.Courses
                                .Include(x => x.Teachers)
                                .FirstOrDefault(x => x.Lms_id.Equals(listCoursesItem.id))
                                ?.Teachers.Add(db.Teachers.FirstOrDefault(x => x.Lms_id.Equals(lmsTeacher.Lms_id)));
                            await db.SaveChangesAsync();
                        }
                    }
            }

            foreach (var courseItem in db.Courses.Include(x => x.Students))
            {
                var studentsOnCourse = await CoursesQueries.ListUsersInCourseAsync(courseItem.Lms_id.ToString(),
                    new ListUsersInCourseParams()
                    {
                        include = new List<UserInclude>() { UserInclude.EMAIL },
                        enrollment_state = new List<UserEnrollmentState>() { UserEnrollmentState.ACTIVE },
                        enrollment_type = UserEnrollmentType.STUDENT,
                        number_students = courseItem.Total_students
                    });
                foreach (var studentItem in studentsOnCourse)
                {
                    var lmsStudent = new LmsStudent()
                    {
                        Lms_id = studentItem.id,
                        Name = textInfo.ToTitleCase(studentItem.short_name.Split(' ')[0].ToLower()),
                        Surname = textInfo.ToTitleCase(studentItem.short_name.Split(' ').Length > 1
                            ? studentItem.short_name.Split(' ')[1].ToLower()
                            : string.Empty),
                        Patronymic = null,
                        Login_id = studentItem.login_id,
                        Email = studentItem.email,
                        Role = textInfo.ToTitleCase(CourseUserEnrollmentType.STUDENT.ToString().ToLower())
                    };

                    if (db.Students.Count(x => x.Lms_id.Equals(lmsStudent.Lms_id)) <= 0)
                    {
                        db.Students.Add(lmsStudent);
                        await db.SaveChangesAsync();
                    }

                    if (courseItem.Students.Count(x => x.Lms_id.Equals(lmsStudent.Lms_id)) <= 0)
                    {
                        courseItem.Students.Add(db.Students.FirstOrDefault(x => x.Lms_id.Equals(lmsStudent.Lms_id)));
                        await db.SaveChangesAsync();
                    }
                }
            }

            foreach (var lmsCourse in db.Courses.Include(x => x.Teachers).Include(x => x.Students))
            {
                Console.WriteLine($"{lmsCourse.Name} {lmsCourse.Course_code}");
                foreach (var lmsTeacher in lmsCourse.Teachers)
                    Console.WriteLine($"\t{lmsTeacher.Name}\t{lmsTeacher.Surname}\t{lmsTeacher.Patronymic}");
                foreach (var lmsStudent in lmsCourse.Students)
                    Console.WriteLine($"\t\t{lmsStudent.Name}\t{lmsStudent.Surname}\t{lmsStudent.Email}");
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}