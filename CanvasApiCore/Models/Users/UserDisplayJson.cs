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
    public class UserDisplayJson : BaseEntityJson
    {
        /// <summary>
        /// отображаемое имя пользователя
        /// </summary>
        public string display_name;
        /// <summary>
        /// URL аватарки
        /// </summary>
        public string avatar_image_url;
        /// <summary>
        /// URL на страницу пользователя
        /// </summary>
        public string html_url;
    }
}
