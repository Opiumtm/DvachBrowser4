using DvachBrowser4.Core.Models.Board;
using DvachBrowser4.Core.Models.Extensions;
using DvachBrowser4.Core.Models.Posts;

namespace DvachBrowser4.Core.Models.Makaba
{
    /// <summary>
    /// Расширения модели для Makaba.
    /// </summary>
    public static class MakabaModelExtensions
    {
        /// <summary>
        /// Зарегистрировать расширения.
        /// </summary>
        public static void RegisterExtensions()
        {
            DataContractExtensions.AddExtension<BoardPageTreeExtension, MakabaBoardPageExtension>();
            DataContractExtensions.AddExtension<BoardReferenceExtension, MakabaBoardReferenceExtension>();
            DataContractExtensions.AddExtension<PostTreeCollectionExtension, MakabaCollectionExtension>();
        }
    }
}