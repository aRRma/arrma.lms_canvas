using System;
using System.Collections.Generic;

namespace arrma.lms_canvas.api_test.api_models.Courses
{
    // see https://canvas.instructure.com/doc/api/courses

    /// <summary>
    /// Обьект описывающий курс в LMS Canvas
    /// </summary>
    class Course : CanvasEntity
    {
        public string sis_course_id;
        public string uuid;
        public string integration_id;
        public int? sis_import_id;
        public string course_code;
        public string workflow_state;
        public int? account_id;
        public int? root_account_id;
        public int? enrollment_term_id;
        public int? grading_standard_id;
        public DateTime? start_at;
        public DateTime? end_at;
        public string locale;
        public CourseEnrollment[] enrollments;
        public int? total_students;
        public CourseCalendarLinkModel calendar;
        public string default_view;
        public string syllabus_body;
        public int? needs_grading_count;
        public CourseTerm term;
        public CourseProgress course_progress;
        public bool? apply_assignment_group_weights;
        public Users.UserDisplay[] teachers;
        public Dictionary<string, bool?> permissions;
        public bool? is_public;
        public bool? is_public_to_auth_users;
        public bool? public_syllabus;
        public bool? public_syllabus_to_auth;
        public string public_description;
        public int? storage_quota_mb;
        public int? storage_quota_used_mb;
        public bool? hide_final_grades;
        public string license;
        public bool? allow_student_assignment_edits;
        public bool? allow_wiki_comments;
        public bool? allow_student_forum_attachments;
        public bool? open_enrollment;
        public bool? self_enrollment;
        public bool? restrict_enrollments_to_course_dates;
        public string course_format;
        public bool? access_restricted_by_date;
        public string time_zone;
        public bool? blueprint;
        //public blueprint_restrictions;
        //public blueprint_restrictions_by_object_type;
    }

    /// <summary>
    /// Календарь курса?
    /// </summary>
    class CourseCalendarLinkModel
    {
        public string ics;
    }

    /// <summary>
    /// Срока обучения
    /// </summary>
    class CourseTerm : CanvasEntity
    {
        public DateTime? start_at;
        public DateTime? end_at;
        public string workflow_state;
        public int? grading_period_group_id;
    }

    /// <summary>
    /// Прогресс курса
    /// </summary>
    class CourseProgress
    {
        public int? requirement_count;
        public int? requirement_completed_count;
        public string? next_requirement_url;
        public DateTime? completed_at;
    }
}
