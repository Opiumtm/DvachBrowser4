using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Other;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Дерево постов в ветке.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(ArchiveThreadTree))]
    public class ThreadTree : PostTreeCollection
    {
        /// <summary>
        /// Время модификации.
        /// </summary>
        [DataMember]
        public string LastModified { get; set; }
    }
}