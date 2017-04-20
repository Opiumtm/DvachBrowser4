using System;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Extensions;

namespace DvachBrowser4.Core.Models.Links
{
    /// <summary>
    /// Базовый класс для ссылки на борде.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(nameof(GetKnownTypes))]
    public abstract class BoardLinkBase : IDeepCloneable<BoardLinkBase>
    {
        /// <summary>
        /// Движок.
        /// </summary>
        [DataMember]
        public string Engine { get; set; }

        /// <summary>
        /// Тип ссылки.
        /// </summary>
        [IgnoreDataMember]
        public BoardLinkKind LinkKind => GetLinkKind();

        /// <summary>
        /// Получить тип ссылки.
        /// </summary>
        /// <returns>Тип ссылки.</returns>
        protected abstract BoardLinkKind GetLinkKind();

        /// <summary>
        /// Клонировать.
        /// </summary>
        /// <returns>Клон.</returns>
        public abstract BoardLinkBase DeepClone();

        /// <summary>
        /// Получить известные типы.
        /// </summary>
        /// <returns>Известные типы.</returns>
        private static Type[] GetKnownTypes()
        {
            return DataContractExtensions.GetKnownTypes<BoardLinkBase>();
        }
    }
}