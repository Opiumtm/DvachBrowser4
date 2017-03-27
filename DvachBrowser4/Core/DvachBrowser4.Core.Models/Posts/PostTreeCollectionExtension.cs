using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Makaba;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Расширение коллекции постов.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(MakabaCollectionExtension))]
    public abstract class PostTreeCollectionExtension
    {
    }
}