using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    class LmsAssignmentGroup : LmsBaseEntity
    {
        public List<LmsAssignment> Assignments { get; set; } = new List<LmsAssignment>();
    }
}
