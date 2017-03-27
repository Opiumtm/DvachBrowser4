using System.Collections.Generic;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Источник списка постов.
    /// </summary>
    public interface IPostTreeListSource
    {
        /// <summary>
        /// Получить посты.
        /// </summary>
        /// <returns>Посты.</returns>
        Task<IList<PostTree>> GetPosts();
    }
}