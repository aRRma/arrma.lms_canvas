using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Courses
{
    /// <summary>
    /// Список зачислений, связывающих текущего пользователя с курсом
    /// </summary>
    class CourseEnrollment
    {
        public string type;
        public string role;
        public int role_id;
        public int user_id;
        public string enrollment_state;
    }
}
