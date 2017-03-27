using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Каталог.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class CatalogTree : PostTreeCollection
    {
        /// <summary>
        /// Штамп изменения.
        /// </summary>
        [DataMember]
        public string ETag { get; set; }
    }
}