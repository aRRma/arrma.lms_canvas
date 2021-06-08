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
        public string sortable_name;
        public string short_name;
        public string sis_user_id;
        public int? sis_import_id;
        public string integration_id;
        public string login_id;
        public string avatar_url;
        public Enrollment[] enrollments;
        public string email;
        public string locale;
        public string last_login;
        public string time_zone;
        public string bio;
    }
}