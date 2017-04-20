using Microsoft.Extensions.DependencyInjection;

namespace DvachBrowser4.Core.Serialization
{
    /// <summary>
    /// Инициализатор сервисов сериализации.
    /// </summary>
    public static class SerializationServicesInitializer
    {
        /// <summary>
        /// Конфигурировать сервисы.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void AddSerializationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISerializationProvider, BinaryDataContractSerializationProvider>();
        }
    }
}