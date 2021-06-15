using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Enrollments;

namespace CanvasApiCore.Models.Users
{
    /// <summary>
    /// Пользователя LMS Canvas
    /// </summary>
    public class User : CanvasEntity
    {
        /// <summary>
        /// Отсортированное имя (Ф, И, О)
        /// </summary>
        public string sortable_name;
        /// <summary>
        /// Короткое имя
        /// </summary>
        public string short_name;
        /// <summary>
        /// ID пользователя SIS с которой связана регистрация (вкл. только если пользователь имеет право просматривать SIS информацию) (прим. m2010218@edu.misis.ru)
        /// </summary>
        public string sis_user_id;
        /// <summary>
        /// ID для импорта SIS
        /// </summary>
        public int? sis_import_id;
        /// <summary>
        /// ID интеграции пользователя
        /// </summary>
        public string integration_id;
        /// <summary>
        /// Уникальный ID для входа пользователя
        /// </summary>
        public string login_id;
        /// <summary>
        /// URL на аватарку
        /// </summary>
        public string avatar_url;
        /// <summary>
        /// Регистрации
        /// </summary>
        public Enrollment[] enrollments;
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string email;
        /// <summary>
        /// Локаль
        /// </summary>
        public string locale;
        /// <summary>
        /// Время последнего логина (почему-то в API тип string)
        /// </summary>
        public string last_login;
        /// <summary>
        /// Временная зона (IANA)
        /// </summary>
        public string time_zone;
        /// <summary>
        /// Описание пользователя
        /// </summary>
        public string bio;
    }
}