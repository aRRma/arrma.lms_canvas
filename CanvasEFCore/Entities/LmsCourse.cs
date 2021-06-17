using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    public class LmsCourse
    {
        public int Id { get; set; }
        [Required]
        public int Lms_id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<LmsTeacher> Teachers { get; set; } = new List<LmsTeacher>();
        public List<LmsStudent> Students { get; set; } = new List<LmsStudent>();
        public List<LmsAssignmentGroup> AssignmentGroups { get; set; } = new List<LmsAssignmentGroup>();

        public string Course_code { get; set; }
        public int? Total_students { get; set; }
        public int? Total_teachers { get; set; }
        public int? Needs_grading_count { get; set; }
        public string Workflow_state { get; set; }
        public DateTime? Start_at { get; set; }
        public DateTime? End_at { get; set; }
    }
}
