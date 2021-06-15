using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    public class LmsCourse : LmsBaseEntity
    {
        public string Course_code { get; set; }
        public string Workflow_state { get; set; }
        public DateTime? Start_at { get; set; }
        public DateTime? End_at { get; set; }


        public List<LmsTeacher> Teachers { get; set; } = new List<LmsTeacher>();
        public List<LmsStudent> Students { get; set; } = new List<LmsStudent>();
        public List<LmsAssignmentGroup> AssignmentGroups { get; set; } = new List<LmsAssignmentGroup>();
    }
}
