using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Изображение.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(PostImage))]
    [KnownType(typeof(PostImageWithThumbnail))]
    public abstract class PostImageBase : PostMediaBase
    {
        /// <summary>
        /// Имя изображения.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Высота изображения.
        /// </summary>
        [DataMember]
        public int Height { get; set; }

        /// <summary>
        /// Ширина изображения.
        /// </summary>
        [DataMember]
        public int Width { get; set; }
    }
}