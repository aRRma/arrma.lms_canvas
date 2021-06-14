using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCoreDb.Entities
{
    class LmsSubmission : LmsBaseEntity
    {
        public int AttachmentId { get; set; }
        public LmsAttachment Attachment { get; set; }
    }
}
