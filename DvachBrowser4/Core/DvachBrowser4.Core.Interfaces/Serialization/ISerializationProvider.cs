namespace DvachBrowser4.Core.Serialization
{
    /// <summary>
    /// Провайдер сериализации.
    /// </summary>
    public interface ISerializationProvider
    {
        /// <summary>
        /// Получить сериализатор для типа.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <returns>Сериализатор.</returns>
        ISerializer<T> GetSerializer<T>();
    }
}