using System;

namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Потребитель сервисов.
    /// </summary>
    public interface IServiceConsumer
    {
        /// <summary>
        /// Присоединить к сервисам.
        /// </summary>
        /// <param name="provider">Провайдер сервисов.</param>
        /// <param name="force">Форсировать повторную инициализацию.</param>
        void ConnectToServices(IServiceProvider provider, bool force);
    }
}