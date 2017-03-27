using System.Collections.Generic;
using DvachBrowser4.Core.Models.Links;

namespace DvachBrowser4.Core.Models.Services
{
    /// <summary>
    /// Сервис хэша ссылок.
    /// </summary>
    public interface ILinkHashService
    {
        /// <summary>
        /// Получить хэш ссылки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Хэш.</returns>
        string GetLinkHash(BoardLinkBase link);

        /// <summary>
        /// Получить средство сравнения.
        /// </summary>
        /// <returns>Средство сравнения.</returns>
        IEqualityComparer<BoardLinkBase> GetComparer();

    }
}