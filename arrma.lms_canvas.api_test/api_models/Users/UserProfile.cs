using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Users
{
    /// <summary>
    /// Обьект профиля пользователя
    /// </summary>
    class UserProfile : CanvasEntity
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
        public CalendarLinkModel calendar;
        public string time_zone;
        public string locale;
    }
}
