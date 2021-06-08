using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Submissions
{
    /// <summary>
    /// Дополнительные параметры для запроса "List submissions for multiple assignments"
    /// </summary>
    class ListMultiSubmQueryAddParams
    {
        /// <summary>
        /// ID студентов (если ничего не указанно, то венутся представления для текущего пользователя, если "all", то вернутся для всех студентов на курсе)
        /// </summary>
        public string[] student_ids;
        /// <summary>
        /// ID Заданий (если ничего не указанно, то возвращается представления ВСЕХ заданий)
        /// </summary>
        public string[] assignment_ids;
        /// <summary>
        /// Флаг группировки (если true, то группируется по пользователям)
        /// </summary>
        public bool? grouped;
        /// <summary>
        /// Флаг связанный с регистрацией через SIS (хз для чего)
        /// </summary>
        public bool? post_to_sis;
        /// <summary>
        /// Для запроса заданий после указанной даты
        /// </summary>
        public DateTime? submitted_since;
        /// <summary>
        /// период оценки (хз дял чего)
        /// </summary>
        public int? grading_period_id;
        /// <summary>
        /// Статус выполнения представления
        /// </summary>
        public SubmissionWorkflowState workflow_state;
        /// <summary>
        /// Статус зачисления (если не казан, то вернутся все кроме удаленных)
        /// </summary>
        public SubmissionEnrollmentState enrollment_state;
        /// <summary>
        /// Состояние на основе даты (если false, то будет игнорировать фактическое сост. зачисления)
        /// </summary>
        public bool? state_based_on_date;
        /// <summary>
        /// Порядок запроса (не влияет на групповой режим)
        /// </summary>
        public SubmissionOrder order;
        /// <summary>
        /// Направление порядка запроса (не влияет на групповой режим)
        /// </summary>
        public SubmissionOrderDir order_direction;
        /// <summary>
        /// Список дополнительных параметров для запроса
        /// </summary>
        public List<SubmissionInclude> include;

        public ListMultiSubmQueryAddParams()
        {
            //все поля установлены либо в null, NONE или значение по умолчанию согласно API
            
            student_ids = null;
            assignment_ids = null;
            grouped = false;
            post_to_sis = false;
            submitted_since = null;
            grading_period_id = null;
            workflow_state = SubmissionWorkflowState.NONE;
            enrollment_state = SubmissionEnrollmentState.NONE;
            state_based_on_date = true;
            order = SubmissionOrder.NONE;
            order_direction = SubmissionOrderDir.ASCENDING;
            include = new List<SubmissionInclude>() {SubmissionInclude.NONE};
        }
    }
}
