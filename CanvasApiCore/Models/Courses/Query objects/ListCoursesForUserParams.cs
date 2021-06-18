using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models;

namespace CanvasApiCore.Models
{
    /// <summary>
    /// Дополнительные параметры для запроса "ListCoursesForUserParams"
    /// </summary>
    public class ListCoursesForUserParams
    {
        /// <summary>
        /// Список дополнительных параметров для запроса
        /// </summary>
        public List<CourseInclude> include;
        /// <summary>
        /// Состояние курса
        /// </summary>
        public List<CourseState> state;
        /// <summary>
        /// Статус регистрации пользователя на курс
        /// </summary>
        public CourseUserEnrollmentState enrollment_state;

        public ListCoursesForUserParams()
        {
            include = new List<CourseInclude>() { CourseInclude.NONE };
            state = new List<CourseState>() { CourseState.NONE };
            enrollment_state = CourseUserEnrollmentState.NONE;
        }
    }
}