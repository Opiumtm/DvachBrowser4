using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Иконка (/po/ и некоторые другие борды).
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostTreeIconExtension : PostTreeExtension
    {
        /// <summary>
        /// Ссылка на иконку.
        /// </summary>
        [DataMember]
        public string Uri { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [DataMember]
        public string Description { get; set; }         
    }
}