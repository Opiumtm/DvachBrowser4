﻿using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posting
{
    /// <summary>
    /// Иконка.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostingCapabilityIcon
    {
        /// <summary>
        /// Номер.
        /// </summary>
        [DataMember]
        public int Number { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}