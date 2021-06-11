using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApiTest
    {
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

        //Console.WriteLine("Запрашиваем массив представлений заданий для n-го количества студентов");
        //List<GroupedSubmissions> studentSubmissions = await SubmissionsQueries.ListSubmissionsForMultiAssignmentsAsync(course_id, new ListMultiSubmParams()
        //{
        //    student_ids = new[] { student_id },
        //    grouped = true,
        //    workflow_state = SubmissionWorkflowState.GRADED,
        //    include = new List<SubmissionInclude>() { SubmissionInclude.ASSIGNMENT, SubmissionInclude.USER }
        //});
        //foreach (var item in studentSubmissions)
        //{
        //    Console.WriteLine($"Студент Id: {item.user_id}\nФИО: {item.submissions[0].user.short_name}\nSis: {item.sis_user_id}");
        //    foreach (var submissions in item.submissions)
        //        Console.WriteLine($"\t\tId задания: {submissions?.assignment_id}\tНазвание: {submissions.assignment?.name}\tСтатус: {submissions?.workflow_state}\tОценка: {(submissions?.grade == null ? "не известно" : submissions?.grade)}\tВовремя: {!submissions?.late}\tПроверил: {submissions?.grader_id}");
        //}
        //Console.WriteLine();

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
    }
}
