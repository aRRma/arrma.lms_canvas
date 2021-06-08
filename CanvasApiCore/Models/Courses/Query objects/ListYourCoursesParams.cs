using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Courses;

namespace CanvasApiCore.Models.Query_objects
{
    /// <summary>
    /// Дополнительные параметры для запроса "ListYourCoursesAsync"
    /// </summary>
    public class ListYourCoursesParams
    {
        /// <summary>
        /// Тип зачисления пользователя на курс (игнорируется если задан enrollment_role)
        /// </summary>
        public CourseEnrollmentRole enrollment_type;
        /// <summary>
        /// УСТАРЕЛО. Роль пользователя на курсе
        /// </summary>
        public string enrollment_role;
        /// <summary>
        /// ID роли пользователя на курсе
        /// </summary>
        public int? enrollment_role_id;
        /// <summary>
        /// Статус регистрации пользователя на курс
        /// </summary>
        public CourseEnrollmentState enrollment_state;
        /// <summary>
        /// Запросить курсы созданные по шаблону
        /// </summary>
        public bool? exclude_blueprint_courses;
        /// <summary>
        /// Список дополнительных параметров для запроса
        /// </summary>
        public List<CourseInclude> include;
        /// <summary>
        /// Состояние курса
        /// </summary>
        public List<CourseState> state;

        public ListYourCoursesParams()
        {
            enrollment_type = CourseEnrollmentRole.NONE;
            enrollment_role = null;
            enrollment_role_id = null;
            enrollment_state = CourseEnrollmentState.NONE;
            exclude_blueprint_courses = null;
            include = new List<CourseInclude>() { CourseInclude.NONE };
            state = new List<CourseState>() { CourseState.NONE };
        }
    }
}
