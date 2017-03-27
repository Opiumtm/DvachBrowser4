using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posting
{
    /// <summary>
    /// Поле для постинга медиа-файлов.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostingMediaFileCapability : PostingCapability
    {
        /// <summary>
        /// Максимальное количество файлов.
        /// </summary>
        [DataMember]
        public int? MaxFileCount { get; set; } 
    }
}