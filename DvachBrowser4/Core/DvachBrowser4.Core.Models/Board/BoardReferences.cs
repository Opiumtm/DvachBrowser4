using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Board
{
    /// <summary>
    /// Ссылки на борды.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class BoardReferences
    {
        /// <summary>
        /// Корневая ссылка.
        /// </summary>
        [DataMember]
        public BoardLinkBase RootLink { get; set; }

        /// <summary>
        /// Ссылки.
        /// </summary>
        [DataMember]
        public List<BoardReference> References { get; set; }

        /// <summary>
        /// Время последней проверки.
        /// </summary>
        [DataMember]
        public DateTime CheckTime { get; set; }
    }
}