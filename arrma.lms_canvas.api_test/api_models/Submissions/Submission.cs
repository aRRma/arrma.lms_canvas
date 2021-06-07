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
        public int? assignment_id;
        public Attachment.Attachment[] attachments;
        public DateTime? cached_due_date;
        public bool? excused;
        public string grade;                            //оценка
        public bool? grade_matches_current_submission;
        public bool? late;
        public double? score;
        public SubmissionType? submission_type;
        public DateTime? submitted_at;                  //отправлено
        public string url;
        public int? user_id;
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
