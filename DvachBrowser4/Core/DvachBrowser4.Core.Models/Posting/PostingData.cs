﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Posting
{
    /// <summary>
    /// Данные для постинга.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(PostingMediaFiles))]
    [KnownType(typeof(DraftPostingData))]
    public class PostingData
    {
        /// <summary>
        /// Ссылка.
        /// </summary>
        [DataMember]
        public BoardLinkBase Link { get; set; }

        /// <summary>
        /// Время сохранения.
        /// </summary>
        [DataMember]
        public DateTime SaveTime { get; set; }

        /// <summary>
        /// Данные полей.
        /// </summary>
        [DataMember]
        public Dictionary<PostingFieldSemanticRole, object> FieldData { get; set; }
    }
}