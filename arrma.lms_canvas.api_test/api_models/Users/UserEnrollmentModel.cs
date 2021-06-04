using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Users
{
    class UserEnrollmentModel
    {
        public int id;
        public int? user_id;
        public int? course_id;
        public string type;
        public DateTime? create_at;
        public DateTime? update_at;
        public int? associated_user_id;
        public string start_at;
        public string end_at;
        public int? course_section_id;
        public int? root_account_id;
        public bool limit_privileges_to_course_section;
        public string enrollment_state;
        public string role;
        public int? role_id;
        public DateTime? last_activity_at;
        public int? total_activity_time;
        public UserGradesModel grades;
        public string sis_account_id;           //подразделение (институт?)
        public string sis_course_id;
        public string course_integration_id;
        public string sis_section_id;
        public string section_integration_id;
        public string sis_user_id;
        public string html_url;
    }
}