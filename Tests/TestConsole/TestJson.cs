using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int account_id { get; set; }
        public string uuid { get; set; }
        public DateTime start_at { get; set; }
        public object grading_standard_id { get; set; }
        public bool is_public { get; set; }
        public string course_code { get; set; }
        public string default_view { get; set; }
        public int root_account_id { get; set; }
        public int enrollment_term_id { get; set; }
        public DateTime? end_at { get; set; }
        public bool public_syllabus { get; set; }
        public bool public_syllabus_to_auth { get; set; }
        public int storage_quota_mb { get; set; }
        public bool is_public_to_auth_users { get; set; }
        public bool apply_assignment_group_weights { get; set; }
        public Teacher[] teachers { get; set; }
        public Calendar calendar { get; set; }
        public string time_zone { get; set; }
        public bool blueprint { get; set; }
        public object sis_course_id { get; set; }
        public object integration_id { get; set; }
        public Enrollment[] enrollments { get; set; }
        public bool hide_final_grades { get; set; }
        public string workflow_state { get; set; }
        public bool restrict_enrollments_to_course_dates { get; set; }
    }

    public class Calendar
    {
        public string ics { get; set; }
    }

    public class Teacher
    {
        public int id { get; set; }
        public string display_name { get; set; }
        public string avatar_image_url { get; set; }
        public string html_url { get; set; }
    }

    public class Enrollment
    {
        public string type { get; set; }
        public string role { get; set; }
        public int role_id { get; set; }
        public int user_id { get; set; }
        public string enrollment_state { get; set; }
    }

}
