using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Users
{
    /// <summary>
    /// Доп. параметры для запросов информации об пользователях
    /// </summary>
    enum UserInclude
    {
        NONE,
        EMAIL,
        ENROLLMENTS,
        LOCKED,
        AVATAR_URL,
        TEST_STUDENT,
        BIO,
        CUSTOM_LINKS,
        CURRENT_GRADING_PERIOD_SCORES,  // запросить ???что-то с периодами заданий???
    }

    /// <summary>
    /// Тип зачисления пользователя
    /// </summary>
    enum UserEnrollmentType
    {
        NONE,
        STUDENT_VIEW,   //тестовый студент?
        STUDENT = 3,
        TEACHER = 4,
        TA = 5,         //ассистент
        OBSERVER,
        DESIGNER
    }

    /// <summary>
    /// Состояние зачисления пользователя
    /// </summary>
    enum UserEnrollmentState
    {
        NONE,
        ACTIVE,
        INVITED,
        REJECTED,
        COMPLETED,
        INACTIVE
    }
}
