using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Courses;

namespace CanvasApiCore.Models.Users
{
    /// <summary>
    /// Профиля пользователя
    /// </summary>
    public class UserProfileJson : BaseEntityJson
    {
        /// <summary>
        /// Короткое имя пользователя
        /// </summary>
        public string short_name;
        /// <summary>
        /// Отсортированное имя пользователя
        /// </summary>
        public string sortable_name;
        /// <summary>
        /// Название
        /// </summary>
        public string title;
        /// <summary>
        /// Описание пользователя
        /// </summary>
        public string bio;
        /// <summary>
        /// Основной адрес электронной почты
        /// </summary>
        public string primary_email;
        /// <summary>
        /// Уникальный ID для входа пользователя
        /// </summary>
        public string login_id;
        /// <summary>
        /// ID пользователя SIS с которой связана регистрация (вкл. только если пользователь имеет право просматривать SIS информацию) (прим. m2010218@edu.misis.ru)
        /// </summary>
        public string sis_user_id;
        /// <summary>
        /// ID пользователя LTI с которой связана регистрация
        /// </summary>
        public string lti_user_id;
        /// <summary>
        /// URL на аватарку
        /// </summary>
        public string avatar_url;
        /// <summary>
        /// календарь пользователя
        /// </summary>
        public CourseCalendarLinkModel calendar;
        /// <summary>
        /// Временная зона (IANA)
        /// </summary>
        public string time_zone;
        /// <summary>
        /// Локаль
        /// </summary>
        public string locale;
    }
}
