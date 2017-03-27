using System.Collections.Generic;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Коллекция постов.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostTreeContainer
    {
        /// <summary>
        /// Ссылка.
        /// </summary>
        [DataMember]
        public BoardLinkBase Link { get; set; }

        /// <summary>
        /// Посты.
        /// </summary>
        [DataMember]
        public List<PostTree> Posts { get; set; }
    }
}