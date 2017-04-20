using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Makaba
{
    /// <summary>
    /// Ссылка на иконки.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class MakabaIconReference
    {
        /// <summary>
        /// Номер.
        /// </summary>
        [DataMember]
        public int Number { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// URL.
        /// </summary>
        [DataMember]
        public string Url { get; set; }
    }
}