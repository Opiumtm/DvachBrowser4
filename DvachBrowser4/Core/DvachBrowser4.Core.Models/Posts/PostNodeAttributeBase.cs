using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Базовый класс атрибута поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(PostNodeAttribute))]
    [KnownType(typeof(PostNodeLinkAttribute))]
    [KnownType(typeof(PostNodeBoardLinkAttribute))]
    public class PostNodeAttributeBase
    {
    }
}