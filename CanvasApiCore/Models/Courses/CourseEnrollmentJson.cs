using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models;

namespace CanvasApiCore.Models
{
    /// <summary>
    /// Список зачислений, связывающих текущего пользователя с курсом
    /// </summary>
    public class CourseEnrollmentJson
    {
        /// <summary>
        /// Тип регистрации пользователя на курс
        /// </summary>
        public string type;
        /// <summary>
        /// Роль пользователя на курсе
        /// </summary>
        public string role;
        /// <summary>
        /// ID роли пользователя
        /// </summary>
        public int? role_id;
        /// <summary>
        /// ID пользователя
        /// </summary>
        public int? user_id;
        /// <summary>
        /// Состояние регистрации на курс пользователя
        /// </summary>
        public string enrollment_state;
    }
}
