﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Страница борды.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class BoardPageTree
    {
        /// <summary>
        /// Ссылка.
        /// </summary>
        [DataMember]
        public BoardLinkBase Link { get; set; }

        /// <summary>
        /// Родительская ссылка.
        /// </summary>
        [DataMember]
        public BoardLinkBase ParentLink { get; set; }

        /// <summary>
        /// Максимальный номер страницы (null - неизвестно).
        /// </summary>
        [DataMember]
        public int? MaxPage { get; set; }

        /// <summary>
        /// Номер страницы (null - неизвестно).
        /// </summary>
        [DataMember]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Время модификации.
        /// </summary>
        [DataMember]
        public string LastModified { get; set; }

        /// <summary>
        /// Треды.
        /// </summary>
        [DataMember]
        public List<ThreadPreviewTree> Threads { get; set; }

        /// <summary>
        /// Расширения.
        /// </summary>
        [DataMember]
        public List<BoardPageTreeExtension> Extensions { get; set; }
    }
}