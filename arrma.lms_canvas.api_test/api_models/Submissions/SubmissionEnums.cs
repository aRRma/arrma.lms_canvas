using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Submissions
{
    enum SubmissionType
    {
        NONE,
        ONLINE_QUIZ,
        ON_PAPER,
        DISCUSSION_TOPIC,
        EXTERNAL_TOOL,
        ONLINE_UPLOAD,
        ONLINE_TEXT_ENTRY,
        ONLINE_URL,
        STUDENT_ANNOTATION
    }

    enum SubmissionInclude
    {
        NONE,
        SUBMISSION_HISTORY,
        SUBMISSION_COMMENTS,
        RUBRIC_ASSESSMENT,
        ASSIGNMENTS,
        TOTAL_SCORES,
        VISIBILITY,
        COURSE,
        USER
    }

    enum SubmissionWorkflowState
    {
        NONE,
        SUBMITTED,
        UNSUBMITTED,
        GRADED,
        PENDING_REVIEW
    }
}
