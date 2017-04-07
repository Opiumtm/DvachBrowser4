using System;
using System.IO;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Serialization
{
    /// <summary>
    /// Сериализатор.
    /// </summary>
    /// <typeparam name="T">Тип объекта.</typeparam>
    public interface ISerializer<T>
    {
        /// <summary>
        /// Сериализовать объект.
        /// </summary>
        /// <param name="src">Исходный объект.</param>
        /// <param name="stream">Поток.</param>
        /// <returns>Таск.</returns>
        Task Serialize(T src, Stream stream);

        /// <summary>
        /// Десериализовать объект.
        /// </summary>
        /// <param name="stream">Поток.</param>
        /// <returns>Таск.</returns>
        Task<T> Deserialize(Stream stream);
    }
}