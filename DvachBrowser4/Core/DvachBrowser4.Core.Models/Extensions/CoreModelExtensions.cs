using DvachBrowser4.Core.Models.Board;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Extensions
{
    /// <summary>
    /// Стандартные расширения.
    /// </summary>
    public static class CoreModelExtensions
    {
        /// <summary>
        /// Зарегистрировать расширения.
        /// </summary>
        public static void RegisterExtensions()
        {
            DataContractExtensions.AddExtension<BoardReferenceExtension, BoardReferencePostingExtension>();

            DataContractExtensions.AddExtension<BoardLinkBase, BoardLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, BoardPageLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, ThreadLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, ThreadPartLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, PostLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, BoardMediaLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, MediaLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, YoutubeLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, RootLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, ThreadTagLink>();
            DataContractExtensions.AddExtension<BoardLinkBase, BoardCatalogLink>();
        }
    }
}