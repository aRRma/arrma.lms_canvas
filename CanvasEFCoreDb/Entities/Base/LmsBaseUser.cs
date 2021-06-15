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
    public class LmsBaseUser : LmsBaseEntity
    {
        public string Login_id { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<LmsCourse> Courses { get; set; } = new List<LmsCourse>();
    }
}
