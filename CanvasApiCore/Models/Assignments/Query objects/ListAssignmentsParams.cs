using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Assignments;

namespace CanvasApiCore.Models.Query_objects
{
    /// <summary>
    /// Дополнительные параметры для запроса "ListAssignmentsParams"
    /// </summary>
    public class ListAssignmentsParams
    {
        /// <summary>
        /// Список дополнительных параметров для запроса
        /// </summary>
        public List<AssignmentInclude> include;
        /// <summary>
        /// Частичное название задания
        /// </summary>
        public string search_term;
        /// <summary>
        /// Переопределить даты заданий (по умолчанию true)
        /// </summary>
        public bool? override_assignment_dates;
        /// <summary>
        /// Нужно оценить заданий по секциям (по умолчанию false)
        /// </summary>
        public bool? needs_grading_count_by_section;
        /// <summary>
        /// Сроки и статус курса
        /// </summary>
        public AssignmentBucket bucket;
        /// <summary>
        /// Массив ID заданий
        /// </summary>
        public string[] assignment_ids;
        /// <summary>
        /// Сортировать по (по умолчанию по позиции)
        /// </summary>
        public AssignmentOrderBy order_by;

        public ListAssignmentsParams()
        {
            include = new List<AssignmentInclude>() { AssignmentInclude.NONE };
            search_term = null;
            override_assignment_dates = null;
            needs_grading_count_by_section = null;
            bucket = AssignmentBucket.NONE;
            assignment_ids = null;
            order_by = AssignmentOrderBy.NONE;
        }
    }
}
