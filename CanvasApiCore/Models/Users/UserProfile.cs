using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApiCore.Models.Users
{
    /// <summary>
    /// Профиля пользователя
    /// </summary>
    public class UserProfile : CanvasEntity
    {
        public string short_name;
        public string sortable_name;
        public string title;
        public string bio;
        public string primary_email;
        public string login_id;
        public string sis_user_id;
        public string lti_user_id;
        public string avatar_url;
        public Courses.CourseCalendarLinkModel calendar;
        public string time_zone;
        public string locale;
    }
}
