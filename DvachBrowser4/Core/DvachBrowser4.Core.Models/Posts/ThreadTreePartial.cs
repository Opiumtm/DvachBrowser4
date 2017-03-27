using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Дерево постов в ветке.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class ThreadTreePartial : PostTreeCollection
    {
    }
}