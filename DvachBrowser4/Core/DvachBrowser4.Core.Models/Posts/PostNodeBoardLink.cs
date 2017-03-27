using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Ссылка на пост на борде.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostNodeBoardLink : PostNodeBase
    {
        /// <summary>
        /// Ссылка на борду.
        /// </summary>
        [DataMember]
        public BoardLinkBase BoardLink { get; set; }
    }
}