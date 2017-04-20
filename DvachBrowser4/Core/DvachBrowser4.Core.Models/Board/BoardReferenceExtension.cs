using System;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Extensions;

namespace DvachBrowser4.Core.Models.Board
{
    /// <summary>
    /// Расширение информации о борде.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(nameof(GetKnownTypes))]
    public abstract class BoardReferenceExtension
    {
        /// <summary>
        /// Получить известные типы.
        /// </summary>
        /// <returns>Известные типы.</returns>
        private static Type[] GetKnownTypes()
        {
            return DataContractExtensions.GetKnownTypes<BoardReferenceExtension>();
        }
    }
}