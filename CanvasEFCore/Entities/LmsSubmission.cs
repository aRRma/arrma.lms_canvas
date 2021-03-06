using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    public class LmsSubmission
    {
        public int Id { get; set; }
        [Required]
        public int Lms_id { get; set; }

        // внешние ключи и навигационные свойства
        public int? AssignmentId { get; set; }
        public LmsAssignment Assignment { get; set; }
        public int? StudentId { get; set; }
        public LmsStudent Student { get; set; }
        public int? GraderId { get; set; }
        [ForeignKey("GraderId")]
        public LmsTeacher Teacher { get; set; }
        public List<LmsAttachment> Attachments { get; set; }

        public string Grade { get; set; }
        public double? Score { get; set; }
        public string Submission_type { get; set; }
        public string Workflow_state { get; set; }
        public int Attempt { get; set; }
        public bool? Late { get; set; }
        public DateTime? Submitted_at { get; set; }
        public DateTime? Graded_at { get; set; }
    }
}
