using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CanvasApiCore.Models.Assignment_Group
{
    /// <summary>
    /// 
    /// </summary>
    public class AssignmentGroup : CanvasEntity
    {
        public int? position;
        public double? group_weight;
        public string sis_source_id;
        public object integration_data;
        public Assignments.Assignment[] assignments;
        //public GradingRules rules;
    }
}
