using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Courses
{
    // see https://canvas.instructure.com/doc/api/courses.html

    /// <summary>
    /// перечисление для запроса по состоянию курса
    /// </summary>
    enum CourseState
    {
        NONE,
        UNPUBLISHED,
        AVAILABLE,
        COMPLETED,
        DELETED
    }

    /// <summary>
    /// перечисление для запроса по типу регистрации на курсе
    /// </summary>
    enum CourseEnrollmentState
    {
        NONE,
        ACTIVE,
        INVITED_OR_PENDING,
        COMPLETED
    }

    /// <summary>
    /// перечисление доп. параметров для запросов информации по курсу
    /// </summary>
    enum CourseInclude
    {
        NONE,
        NEEDS_GRADING_COUNT,            // запросить сколько заданий требуют оценки
        SYLLABUS_BODY,                  // запросить html странницу программы курса
        PUBLIC_DESCRIPTION,             // запросить текст описания курса
        TOTAL_SCORES,                   // запросить запросить общую статистику по заданиям
        CURRENT_GRADING_PERIOD_SCORES,  // запросить ???что-то с периодами заданий???
        TERM,                           // запросить информацию о сроках и статусе курса
        COURSE_PROGRESS,                // запросить информацию об прогрессе курса
        SECTIONS,                       // запросить информацию об разделах
        STORAGE_QUOTA_USED_MD,          // запросить обьем файлов на курсе
        TOTAL_STUDENTS,                 // запросить общее количество студентов на курсе
        PASSBACK_STATUS,                // запросить
        FAVORITES,                      // запросить избранный ли данный курс для пользователя
        TEACHERS,                       // запросить список преподавателей на курсе
        OBSERVED_USERS,                 // запросить список наблюдателей на курсе
        ALL_COURSES,                    // запросить включая удаленные курсы (только для запроса одного курса)
        PERMISSIONS,                    // запросить разрешения текущего пользователя на курс (только для запроса одного курса)
        COURSE_IMAGE                    // запросить
    }

    /// <summary>
    /// перечисление ролей пользователей для запросов информации по курсу
    /// </summary>
    enum CourseEnrollmentRole
    {
        NONE,
        STUDENT = 3,
        TEACHER = 4,
        TA = 5,         //ассистент
        OBSERVER,
        DESIGNER
    }
}