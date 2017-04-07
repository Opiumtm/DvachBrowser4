using System;
using System.IO;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Serialization
{
    /// <summary>
    /// Сервис сериализации.
    /// </summary>
    public sealed class SerializationService : ISerializationService
    {
        private readonly ISerializationProvider _serializationProvider;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="serializationProvider">Провайдер сериализации.</param>
        public SerializationService(ISerializationProvider serializationProvider)
        {
            _serializationProvider = serializationProvider ?? throw new ArgumentNullException(nameof(serializationProvider));
        }

        /// <summary>
        /// Клонировать объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="src">Исходный объект.</param>
        /// <returns>Клон объекта.</returns>
        public async Task<T> DeepClone<T>(T src)
        {
            var serializer = _serializationProvider.GetSerializer<T>();
            using (var str = new MemoryStream())
            {
                await serializer.Serialize(src, str);
                str.Position = 0;
                return await serializer.Deserialize(str);
            }
        }

        /// <summary>
        /// Сериализовать объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="src">Исходный объект.</param>
        /// <param name="stream">Поток.</param>
        /// <returns>Таск.</returns>
        public Task Serialize<T>(T src, Stream stream)
        {
            var serializer = _serializationProvider.GetSerializer<T>();
            return serializer.Serialize(src, stream);
        }

        /// <summary>
        /// Десериализовать объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="stream">Поток.</param>
        /// <returns>Таск.</returns>
        public Task<T> Deserialize<T>(Stream stream)
        {
            var serializer = _serializationProvider.GetSerializer<T>();
            return serializer.Deserialize(stream);
        }
    }
}