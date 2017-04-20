using System;
using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Extensions;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Расширение коллекции постов.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(nameof(GetKnownTypes))]
    public abstract class PostTreeCollectionExtension
    {
        /// <summary>
        /// Получить известные типы.
        /// </summary>
        /// <returns>Известные типы.</returns>
        private static Type[] GetKnownTypes()
        {
            return DataContractExtensions.GetKnownTypes<PostTreeCollectionExtension>();
        }
    }
}