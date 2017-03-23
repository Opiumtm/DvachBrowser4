namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Инициализатор сервисов.
    /// </summary>
    public interface IServicesInitializer
    {
        /// <summary>
        /// Конфигурировать сервисы.
        /// </summary>
        /// <param name="callbacks">Обратные вызовы.</param>
        void ConfigureServices(params ServicesConfigureCallback[] callbacks);
    }
}