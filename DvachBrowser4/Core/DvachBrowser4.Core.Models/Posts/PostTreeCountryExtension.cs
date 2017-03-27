using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Флаг (/ukr/, /nvr/ и некоторые другие борды).
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostTreeCountryExtension : PostTreeExtension
    {
        /// <summary>
        /// Ссылка на иконку.
        /// </summary>
        [DataMember]
        public string Uri { get; set; }
    }
}