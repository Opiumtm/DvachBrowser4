using DvachBrowser4.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace DvachBrowser4.Core
{
    /// <summary>
    /// Инициализатор сервисов-помощников для стандартных интерфейсов.
    /// </summary>
    public static class InterfaceHelperServicesInitializer
    {
        /// <summary>
        /// Конфигурировать сервисы.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void AddInterfaceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISerializationService, SerializationService>();
        }
    }
}