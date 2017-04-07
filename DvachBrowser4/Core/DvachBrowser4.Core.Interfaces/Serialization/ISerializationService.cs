using System.IO;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Serialization
{
    /// <summary>
    /// Сервис сериализации.
    /// </summary>
    public interface ISerializationService
    {
        /// <summary>
        /// Клонировать объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="src">Исходный объект.</param>
        /// <returns>Клон объекта.</returns>
        Task<T> DeepClone<T>(T src);

        /// <summary>
        /// Сериализовать объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="src">Исходный объект.</param>
        /// <param name="stream">Поток.</param>
        /// <returns>Таск.</returns>
        Task Serialize<T>(T src, Stream stream);

        /// <summary>
        /// Десериализовать объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="stream">Поток.</param>
        /// <returns>Таск.</returns>
        Task<T> Deserialize<T>(Stream stream);
    }
}