using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    public class LmsBaseEntity
    {
        public int Id { get; set; }
        [Required]
        public int LmsId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
