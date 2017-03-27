using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Makaba;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Расширение страницы.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(MakabaBoardPageExtension))]
    public abstract class BoardPageTreeExtension
    {         
    }
}