using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    public class LmsAssignmentGroup : LmsBaseEntity
    {
        // внешние ключи и навигационные свойства
        public int? CourseId { get; set; }
        public LmsCourse Course { get; set; }
        public List<LmsAssignment> Assignments { get; set; } = new List<LmsAssignment>();

        public int? Position { get; set; }
        public double? Group_weight { get; set; }
    }
}
