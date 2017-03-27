using System.Runtime.Serialization;
using DvachBrowser4.Core.Models.Other;

namespace DvachBrowser4.Core.Models.Links
{
    /// <summary>
    /// Информация об избранном треде.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class FavoriteThreadInfo : ShortThreadInfo
    {
        /// <summary>
        /// Информация о количестве постов.
        /// </summary>
        [DataMember]
        public PostCountInfo CountInfo { get; set; }

        /// <summary>
        /// Клонировать.
        /// </summary>
        /// <returns>Клон.</returns>
        public override ShortThreadInfo DeepClone()
        {
            return new FavoriteThreadInfo()
            {
                CountInfo = CountInfo?.DeepClone(),
                ViewDate = ViewDate,
                Title = Title,
                CreatedDate = CreatedDate,
                UpdatedDate = UpdatedDate,
                AddedDate = AddedDate,
                SmallImage = SmallImage?.DeepClone()
            };
        }
    }
}