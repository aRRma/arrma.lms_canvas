using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    public class LmsAssignmentGroup
    {
        public int Id { get; set; }
        [Required]
        public int Lms_id { get; set; }
        [Required]
        public string Name { get; set; }

        // внешние ключи и навигационные свойства
        public int? CourseId { get; set; }
        public LmsCourse Course { get; set; }
        public List<LmsAssignment> Assignments { get; set; } = new List<LmsAssignment>();

        public int? Position { get; set; }
    }
}
