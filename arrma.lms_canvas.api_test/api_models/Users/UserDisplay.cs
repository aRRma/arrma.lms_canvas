using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrma.lms_canvas.api_test.api_models.Users
{
    // see https://canvas.instructure.com/doc/api/users.html

    /// <summary>
    /// Отображения пользователя LMS Canvas
    /// </summary>
    class UserDisplay : CanvasEntity
    {
        public string display_name;
        public string avatar_image_url;
        public string html_url;
    }
}
