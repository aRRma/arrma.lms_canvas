using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Courses;

namespace CanvasApiCore.Models.Query_objects
{
    /// <summary>
    /// Дополнительные параметры для запроса "ListUsersInCourseParams"
    /// </summary>
    public class ListUsersInCourseParams
    {
        /// <summary>
        /// Частичное или полное имя пользователя для поиска
        /// </summary>
        public string search_term;
        /// <summary>
        /// Тип регистрации пользователя на курс (игнорируется если задан enrollment_role)
        /// </summary>
        public CourseEnrollmentType enrollment_type;
        /// <summary>
        /// УСТАРЕЛО. Роль пользователя на курсе
        /// </summary>
        public string enrollment_role;
        /// <summary>
        /// ID роли пользователя на курсе
        /// </summary>
        public int? enrollment_role_id;
        /// <summary>
        /// Список дополнительных параметров для запроса
        /// </summary>
        public List<CourseInclude> include;
        /// <summary>
        /// ID пользователя (запросится только он)
        /// </summary>
        public string user_id;
        /// <summary>
        /// Массив ID пользователей
        /// </summary>
        public int[] user_ids;
        /// <summary>
        /// Статус регистрации пользователя на курс
        /// </summary>
        public List<CourseEnrollmentState> enrollment_state;

        public ListUsersInCourseParams()
        {
            search_term = null;
            enrollment_type = CourseEnrollmentType.NONE;
            enrollment_role = null;
            enrollment_role_id = null;
            include = new List<CourseInclude>() { CourseInclude.NONE };
            user_id = null;
            user_ids = null;
            enrollment_state = new List<CourseEnrollmentState>() { CourseEnrollmentState.NONE };
        }
    }
}