using System.Collections.Generic;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Posting;

namespace DvachBrowser4.Core.Models.Board
{
    /// <summary>
    /// Информация о возможностях постинга.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class BoardReferencePostingExtension : BoardReferenceExtension
    {
        /// <summary>
        /// Возможности постинга.
        /// </summary>
        [DataMember]
        public List<PostingCapability> Capabilities { get; set; }
    }
}