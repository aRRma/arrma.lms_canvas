using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using arrma.lms_canvas.api_test.api_models.Assignments;
using Newtonsoft.Json;

namespace arrma.lms_canvas.api_test.api_models.Assignment_Group
{
    class AssignmentGroup : CanvasEntity
    {
        public int? position;
        public double? group_weight;
        public string sis_source_id;
        public object integration_data;
        public Assignment[] assignments;
        //public GradingRules rules;
    }
}
