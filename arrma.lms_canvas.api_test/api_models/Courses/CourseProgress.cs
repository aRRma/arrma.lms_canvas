using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Courses
{
    /// <summary>
    /// Обьект прогресс курса
    /// </summary>
    class CourseProgress
    {
        public int? requirement_count;
        public int? requirement_completed_count;
        public string? next_requirement_url;
        public DateTime? completed_at;
    }
}
