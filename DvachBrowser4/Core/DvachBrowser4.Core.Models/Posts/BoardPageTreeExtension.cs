using System;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Extensions;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Расширение страницы.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(nameof(GetKnownTypes))]
    public abstract class BoardPageTreeExtension
    {
        /// <summary>
        /// Получить известные типы.
        /// </summary>
        /// <returns>Известные типы.</returns>
        private static Type[] GetKnownTypes()
        {
            return DataContractExtensions.GetKnownTypes<BoardPageTreeExtension>();
        }
    }
}