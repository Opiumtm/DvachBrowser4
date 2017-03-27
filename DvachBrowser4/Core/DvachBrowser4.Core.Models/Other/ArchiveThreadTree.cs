using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Posts;

namespace DvachBrowser4.Core.Models.Other
{
    /// <summary>
    /// Ссылка на черновик поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class ArchiveThreadTree : ThreadTree
    {
        /// <summary>
        /// Ссылка на архив.
        /// </summary>
        [DataMember]
        public ArchiveReference Reference { get; set; } 
    }
}