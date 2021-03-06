﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posting
{
    /// <summary>
    /// Поле постинга иконок.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostingIconCapability : PostingCapability
    {
        /// <summary>
        /// Иконки.
        /// </summary>
        [DataMember]
        public List<PostingCapabilityIcon> Icons { get; set; }
    }
}