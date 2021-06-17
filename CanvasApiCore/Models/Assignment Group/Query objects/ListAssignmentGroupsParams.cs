using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models;

namespace CanvasApiCore.Models
{
    /// <summary>
    /// Дополнительные параметры для запроса "ListAssignmentGroupsParams"
    /// </summary>
    public class ListAssignmentGroupsParams
    {
        /// <summary>
        /// Список дополнительных параметров для запроса
        /// </summary>
        public List<AssignmentGroupInclude> include;
        /// <summary>
        /// Список параметров для исключения из запроса
        /// </summary>
        public List<ExcludeAssigmSumbTypes> exclude_assignment_submission_types;
        /// <summary>
        /// Переопределить даты заданий? (по умолчанию true)
        /// </summary>
        public bool? override_assignment_dates;
        /// <summary>
        /// ID оценочного периода
        /// </summary>
        public int? grading_period_id;
        /// <summary>
        /// Запросить задания только для текущего пользователя (нужен grading_period_id и пользователь должен быть студентом)
        /// </summary>
        public bool? scope_assignments_to_student;

        public ListAssignmentGroupsParams()
        {
            include = new List<AssignmentGroupInclude>() { AssignmentGroupInclude.NONE };
            exclude_assignment_submission_types = new List<ExcludeAssigmSumbTypes>() { ExcludeAssigmSumbTypes.NONE };
            override_assignment_dates = null;
            grading_period_id = null;
            scope_assignments_to_student = null;
        }
    }
}
