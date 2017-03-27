using System;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Other
{
    /// <summary>
    /// Ссылка на черновик поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class ArchiveReference
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Информация треда.
        /// </summary>
        [DataMember]
        public ShortThreadInfo ThreadInfo { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        [DataMember]
        public DateTime ArchiveDate { get; set; }
         
    }
}