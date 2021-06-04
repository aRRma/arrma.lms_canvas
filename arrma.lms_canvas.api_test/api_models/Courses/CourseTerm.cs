using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Courses
{
    /// <summary>
    /// Обьект срока обучения
    /// </summary>
    class CourseTerm
    {
        public int? id;
        public string? name;
        public DateTime? start_at;
        public DateTime? end_at;
    }
}
