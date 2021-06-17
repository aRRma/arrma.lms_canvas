using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    /// <summary>
    /// Базовый класс пользователя LMS Canvas
    /// </summary>
    public class LmsBaseUser
    {
        public int Id { get; set; }
        [Required]
        public int Lms_id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login_id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public List<LmsCourse> Courses { get; set; } = new List<LmsCourse>();
    }
}
