using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApiCore.Models.Users
{
    /// <summary>
    /// Отображения пользователя LMS Canvas
    /// </summary>
    public class UserDisplay : CanvasEntity
    {
        public string display_name;
        public string avatar_image_url;
        public string html_url;
    }
}
