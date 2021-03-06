using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    public class LmsAssignment
    {
        public int Id { get; set; }
        [Required]
        public int Lms_id { get; set; }
        [Required]
        public string Name { get; set; }

        // внешние ключи и навигационные свойства
        public int? AssignmentGroupId { get; set; }
        public LmsAssignmentGroup AssignmentGroup { get; set; }
        public List<LmsSubmission> Submissions { get; set; }

        public int? Position { get; set; }
        public string Description { get; set; }
        public int? Needs_grading_count { get; set; }
        public string Allowed_extensions { get; set; }
        public string Submission_types { get; set; }
        public double? Points_possible { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Unlock_at { get; set; }
        public DateTime? Due_at { get; set; }
        public DateTime? Lock_at { get; set; }
    }
}
