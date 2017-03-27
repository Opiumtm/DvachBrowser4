using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Базовый класс для узла поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(PostNode))]
    [KnownType(typeof(PostNodeBreak))]
    [KnownType(typeof(PostTextNode))]
    [KnownType(typeof(PostNodeBoardLink))]
    public abstract class PostNodeBase
    {
    }
}