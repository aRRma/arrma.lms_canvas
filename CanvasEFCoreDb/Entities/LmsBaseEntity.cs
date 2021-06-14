using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    class LmsBaseEntity
    {
        public int Id { get; set; }
        [Required]
        public int LmsId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
