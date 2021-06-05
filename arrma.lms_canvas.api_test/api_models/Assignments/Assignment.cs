using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Assignments
{
    class Assignment : CanvasEntity
    {
        public string description;
        public DateTime? due_at;
        public DateTime? unlock_at;
        public DateTime? lock_at;
        public double? points_possible;
        public string grading_type;
        public int? assignment_group_id;
        public int? grading_standard_id;
        public DateTime? created_at;
        public DateTime? updated_at;
        public bool peer_reviews;
        public bool automatic_peer_reviews;
        public int? position;
        public bool grade_group_students_individually;
        public bool anonymous_peer_reviews;
        public int? group_category_id;
        public bool post_to_sis;
        public bool moderated_grading;
        public bool omit_from_final_grade;
        public bool intra_group_peer_reviews;
        public bool anonymous_instructor_annotations;
        public string secure_params;
        public int? course_id;
        public string[] submission_types;
        public bool has_submitted_submissions;
        public bool due_date_required;
        public int? max_name_length;
        public bool in_closed_grading_period;
        public bool is_quiz_assignment;
        public bool muted;
        public string html_url;
        public bool has_overrides;
        public int? needs_grading_count;    //
        public int? integration_id;
        //public string integration_data;   //хз какой тип :( в api вроде стринг..
        public string[] allowed_extensions; //форматы файлов для загрузки
        public bool published;
        public bool unpublishable;
        public bool only_visible_to_overrides;
        public bool locked_for_user;
        public string submissions_download_url;
        public string[] assignment_visibility;  //массив id пользователей которые видят задание
        public AssignmentDate[] all_dates;      //массив сроков заданий для всех разделов
        public AssignmentOverride[] overrides;  //массив перегрузок задания
    }

    class AssignmentDate
    {
        public int? id;
        public bool @base;
        public string title;        //название раздела
        public DateTime? due_at;    //срок задания
        public DateTime? unlock_at; //открыто 
        public DateTime? lock_at;   //доступно до
    }

    class AssignmentOverride
    {
        public int? id;
        public int? assignment_id;
        public int[] student_ids;
        public int? group_id;
        public int? course_section_id;
        public string title;
        public DateTime? due_at;
        public int? all_day;
        public DateTime? all_day_date;
        public DateTime? unlock_at;
        public DateTime? lock_at;
    }
}