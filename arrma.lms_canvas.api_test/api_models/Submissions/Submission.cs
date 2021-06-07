using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace arrma.lms_canvas.api_test.api_models.Submissions
{
    class StudentSubmissions
    {
        public int? integration_id;
        public string section_id;
        public string sis_user_id;
        public Submission[] submissions;
        public string user_id;
    }
    class Submission : CanvasEntity
    {
        public int? assignment_id;                      //id задания
        public Attachment.Attachment[] attachments;     //прикрепленные файлы
        public DateTime? cached_due_date;               //дата кеширования?! (хз в описании API нету)
        public Courses.Course course;
        public int? attempt;                            //количество попыток
        public string body;                             //было только в тест "user: 32081, quiz: 33811, score: 5.0, time: 2021-03-23 16:58:06 +0300"
        public string grade;                            //статус проверки задания
        public bool? grade_matches_current_submission;
        public string html_url;
        public string preview_url;
        public double? score;                           //оценка
        public SubmissionComment[] submission_comments;
        public string submission_type;
        public DateTime? submitted_at;                  //отправлено
        public string url;
        public int? user_id;
        public int? grader_id;
        public DateTime? grader_at;
        public Users.User user;
        public bool? late;
        public bool? assignment_visible;
        public bool? excused;
        public bool? missing;
        public string late_policy_status;
        public long? points_deducted;
        public long? seconds_late;
        public string workflow_state;                   //состояние оценки (оценено или нет)
    }

    class SubmissionComment : CanvasEntity
    {
        public int? author_id;
        public string author_name;
        public string author;
        public string comment;
        public DateTime? created_at;
        public DateTime? edited_at;
        public MediaComment media_comment;
    }

    class MediaComment
    {
        [JsonProperty(PropertyName = "content-type")]
        public string content_type { get; private set; }

        public string display_name;
        public string media_id;
        public string media_type;
        public string url;
    }
}
