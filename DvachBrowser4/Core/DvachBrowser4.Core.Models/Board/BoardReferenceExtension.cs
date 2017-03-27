using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Makaba;

namespace DvachBrowser4.Core.Models.Board
{
    /// <summary>
    /// Расширение информации о борде.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    [KnownType(typeof(MakabaBoardReferenceExtension))]
    [KnownType(typeof(BoardReferencePostingExtension))]
    public abstract class BoardReferenceExtension
    {
    }
}