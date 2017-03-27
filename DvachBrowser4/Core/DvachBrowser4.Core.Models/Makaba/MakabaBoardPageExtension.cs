using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Posts;

namespace DvachBrowser4.Core.Models.Makaba
{
    /// <summary>
    /// Расширение коллекции Makaba.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class MakabaBoardPageExtension : BoardPageTreeExtension
    {
        /// <summary>
        /// Данные Makaba.
        /// </summary>
        [DataMember]
        public MakabaEntityTree Entity { get; set; }
    }
}