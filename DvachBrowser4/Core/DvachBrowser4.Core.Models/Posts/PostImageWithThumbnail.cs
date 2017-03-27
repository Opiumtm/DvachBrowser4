using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Изображение с уменьшенной копией.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostImageWithThumbnail : PostImageBase
    {
        /// <summary>
        /// Уменьшенная копия.
        /// </summary>
        [DataMember]
        public PostImage Thumbnail { get; set; }
    }
}