﻿using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Links
{
    /// <summary>
    /// Ссылка на часть треда.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class ThreadPartLink : ThreadLink
    {
        /// <summary>
        /// Начиная с поста.
        /// </summary>
        [DataMember]
        public int FromPost { get; set; }

        /// <summary>
        /// Получить тип ссылки.
        /// </summary>
        /// <returns>Тип ссылки.</returns>
        protected override BoardLinkKind GetLinkKind()
        {
            return BoardLinkKind.Thread | BoardLinkKind.PartialThread;
        }

        /// <summary>
        /// Клонировать.
        /// </summary>
        /// <returns>Клон.</returns>
        public override BoardLinkBase DeepClone()
        {
            return new ThreadPartLink() { FromPost = FromPost, Board = Board, Engine = Engine, Thread = Thread };
        }
    }
}