using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    public class LmsAttachment : LmsBaseEntity
    {
        // внешние ключи и навигационные свойства
        public int? SubmissionId { get; set; }
        public LmsSubmission Submission { get; set; }
 
        public string Display_name { get; set; }
        public string File_name { get; set; }
        public string File_format { get; set; }
        public long? Size { get; set; }
        public string Download_url { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
