using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Ссылка.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostNodeLinkAttribute : PostNodeAttributeBase
    {
        /// <summary>
        /// Ссылка.
        /// </summary>
        [DataMember]
        public string LinkUri { get; set; }
    }
}