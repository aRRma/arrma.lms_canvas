using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    class LmsCourse : LmsBaseEntity
    {
        public List<LmsTeacher> Teachers { get; set; } = new List<LmsTeacher>();
        public List<LmsStudent> Students { get; set; } = new List<LmsStudent>();
        public List<LmsAssignmentGroup> AssignmentGroups { get; set; } = new List<LmsAssignmentGroup>();
        public List<LmsAssignment> Assignments { get; set; } = new List<LmsAssignment>();
    }
}
