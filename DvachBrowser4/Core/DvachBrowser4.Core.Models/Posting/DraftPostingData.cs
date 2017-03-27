using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posting
{
    /// <summary>
    /// Черновик поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class DraftPostingData : PostingData
    {
        /// <summary>
        /// Ссылка на черновик.
        /// </summary>
        [DataMember]
        public DraftReference Reference { get; set; }
    }
}