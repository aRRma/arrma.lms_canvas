using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Assignments
{
    enum AssignmentInclude
    {
        NONE,
        ASSIGNMENT_VISIBILITY,  //кто из пользователей может видеть задание
        ALL_DATES,              //сроки задания для всех разделов
        OVERRIDES               //переопределения заданий
    }

    enum AssignmentBucket
    {
        NONE,
        PAST,           //прошедшее
        OVERDUE,        //просроченное
        UNDATED,        //вне даты
        UNGRADED,       //не оценено
        UNSUBMITTED,    //не отправлено
        UPCOMING,       //предстоящее
        FUTURE          //будущее
    }

    enum AssignmentOrderBy
    {
        NONE,
        NAME,
        POSITIONS
    }
}
