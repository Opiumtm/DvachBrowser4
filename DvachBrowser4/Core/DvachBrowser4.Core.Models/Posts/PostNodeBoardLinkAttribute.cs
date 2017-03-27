using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Ссылка на борду.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostNodeBoardLinkAttribute : PostNodeAttributeBase
    {
        /// <summary>
        /// Ссылка.
        /// </summary>
        [DataMember]
        public BoardLinkBase BoardLink { get; set; }
    }
}