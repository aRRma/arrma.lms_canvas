using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    /// <summary>
    /// Базовый класс пользователя LMS Canvas
    /// </summary>
    class LmsBaseUser : LmsBaseEntity
    {
        public string Email { get; set; }
        public List<LmsCourse> Courses { get; set; } = new List<LmsCourse>();
    }
}
