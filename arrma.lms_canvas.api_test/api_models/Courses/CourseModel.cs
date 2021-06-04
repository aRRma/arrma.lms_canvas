using System;
using System.Collections.Generic;
using arrma.lms_canvas.api_test.api_models.Users;

namespace arrma.lms_canvas.api_test.api_models
{
    // see https://canvas.instructure.com/doc/api/courses

    class CourseModel
    {
        public int id;
        public string sis_course_id;
        public string uuid;
        public string integration_id;
        public int? sis_import_id;
        public string name;
        public string course_code;
        public string workflow_state;
        public int? account_id;
        public int? root_account_id;
        public int? enrollment_term_id;
        public int? grading_standard_id;
        public DateTime? start_at;
        public DateTime? end_at;
        public string locale;
        public CourseEnrollmentModel[] enrollments;
        public int? total_students;
        public CalendarLinkModel calendar;
        public string default_view;
        public string syllabus_body;
        public int? needs_grading_count;
        public CourseTermModel term;
        public CourseProgresModel course_progress;
        public bool apply_assignment_group_weights;
        public UserDisplayModel[] teachers;
        public Dictionary<string, bool> permissions;
        public bool is_public;
        public bool is_public_to_auth_users;
        public bool public_syllabus;
        public bool public_syllabus_to_auth;
        public string public_description;
        public int? storage_quota_mb;
        public int? storage_quota_used_mb;
        public bool hide_final_grades;
        public string license;
        public bool allow_student_assignment_edits;
        public bool allow_wiki_comments;
        public bool allow_student_forum_attachments;
        public bool open_enrollment;
        public bool self_enrollment;
        public bool restrict_enrollments_to_course_dates;
        public string course_format;
        public bool access_restricted_by_date;
        public string time_zone;
        public bool blueprint;
        //public blueprint_restrictions;
        //public blueprint_restrictions_by_object_type;
    }
}
