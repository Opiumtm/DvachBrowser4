using Microsoft.Extensions.DependencyInjection;

namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Обратный вызов для конфигурации сервисов в коллекции.
    /// </summary>
    /// <param name="serviceCollection">Коллекция сервисов.</param>
    public delegate void ServicesConfigureCallback(IServiceCollection serviceCollection);
}