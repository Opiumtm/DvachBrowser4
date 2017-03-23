using System;

namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Коннектор сервисов.
    /// </summary>
    public interface IServiceConnector
    {
        /// <summary>
        /// Соединить сервисы.
        /// </summary>
        /// <typeparam name="T">Тип потребителя.</typeparam>
        /// <param name="consumer">Потребитель.</param>
        void Connect<T>(T consumer) where T : IServiceConsumer;

        /// <summary>
        /// Получить провайдер.
        /// </summary>
        /// <returns>Провайдер.</returns>
        IServiceProvider GetProvider();

        /// <summary>
        /// Перестроить провайдер.
        /// </summary>
        void RebuildProvider();
    }
}