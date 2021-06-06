using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace arrma.lms_canvas.api_test.api_models.Attachment
{
    class Attachment : CanvasEntity
    {
        [JsonProperty(PropertyName = "content-type")]
        public string content_type { get; private set; }

        public DateTime? create_at;
        public string display_name;
        public string filename;
        public int? folder_id;
        public bool hidden;
        public bool hidden_for_user;
        public DateTime? lock_at;
        public bool locked;
        public bool locked_for_user;
        public int? media_entry_id;
        public string mime_class;
        public DateTime? modified_at;
        public string preview_url;
        public long? size;
        public string thumbnail_url;
        public DateTime? unlock_at;
        public DateTime? updated_at;
        public string url;
    }
}
