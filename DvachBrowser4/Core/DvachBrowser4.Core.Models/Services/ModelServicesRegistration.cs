using Microsoft.Extensions.DependencyInjection;

namespace DvachBrowser4.Core.Models.Services
{
    /// <summary>
    /// Регистрация сервисов для моделей.
    /// </summary>
    public static class ModelServicesRegistration
    {
        /// <summary>
        /// Конфигурировать сервисы.
        /// </summary>
        /// <param name="serviceCollection">Коллекция сервисов.</param>
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILinkHashService>(new LinkHashService());
            serviceCollection.AddSingleton<ILinkTransformService>(new LinkTransformService());
        }
    }
}