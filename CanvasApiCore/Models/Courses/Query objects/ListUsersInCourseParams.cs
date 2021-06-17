using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models;

namespace CanvasApiCore.Models
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
        /// <remarks>Используем данным так-как запрос все-таки относится к пользователям</remarks>
        public UserEnrollmentType enrollment_type;
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
        /// <remarks>Используем данным так-как запрос все-таки относится к пользователям</remarks>
        public List<UserInclude> include;
        /// <summary>
        /// ID пользователя (запросится только он)
        /// </summary>
        public string user_id;
        /// <summary>
        /// Массив ID пользователей
        /// </summary>
        public int[] user_ids;
        /// <summary>
        /// Статус регистрации пользователя на курсе
        /// </summary>
        /// <remarks>Используем данный тип enum, так-как запрос все-таки относится к пользователям</remarks>
        public List<UserEnrollmentState> enrollment_state;
        /// <summary>
        /// Запросить для количества студентов (запросить это число, нужно для разбивки запроса на страницы)
        /// </summary>
        public int? number_students;

        public ListUsersInCourseParams()
        {
            search_term = null;
            enrollment_type = UserEnrollmentType.NONE;
            enrollment_role = null;
            enrollment_role_id = null;
            include = new List<UserInclude>() { UserInclude.NONE };
            user_id = null;
            user_ids = null;
            enrollment_state = new List<UserEnrollmentState>() { UserEnrollmentState.NONE };
            number_students = null;
        }
    }
}