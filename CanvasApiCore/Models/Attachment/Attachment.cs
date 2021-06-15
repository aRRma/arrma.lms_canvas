using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CanvasApiCore.Models.Attachment
{
    /// <summary>
    /// 
    /// </summary>
    public class Attachment : CanvasEntity
    {
        /// <summary>
        /// Тип файла (хэдер html)
        /// </summary>
        [JsonProperty(PropertyName = "content-type")]
        public string content_type { get; private set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime? created_at;
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string display_name;
        /// <summary>
        /// Имя файла
        /// </summary>
        public string filename;
        /// <summary>
        /// ID директории расположения файла
        /// </summary>
        public int? folder_id;
        /// <summary>
        /// Спрятан
        /// </summary>
        public bool? hidden;
        /// <summary>
        /// Спрятан для пользователей
        /// </summary>
        public bool? hidden_for_user;
        /// <summary>
        /// Дата блокировки
        /// </summary>
        public DateTime? lock_at;
        /// <summary>
        /// Заблокирован
        /// </summary>
        public bool? locked;
        /// <summary>
        /// Заблокирован для пользователей
        /// </summary>
        public bool? locked_for_user;
        /// <summary>
        /// ???
        /// </summary>
        public int? media_entry_id;
        /// <summary>
        /// Формат файла
        /// </summary>
        public string mime_class;
        /// <summary>
        /// Дата модификации
        /// </summary>
        public DateTime? modified_at;
        /// <summary>
        /// URL на превью
        /// </summary>
        public string preview_url;
        /// <summary>
        /// Размер файла в байтах
        /// </summary>
        public long? size;
        /// <summary>
        /// ???
        /// </summary>
        public string thumbnail_url;
        /// <summary>
        /// Дата разблокировав
        /// </summary>
        public DateTime? unlock_at;
        /// <summary>
        /// Дата обновления
        /// </summary>
        public DateTime? updated_at;
        /// <summary>
        /// URL
        /// </summary>
        public string url;
    }
}
