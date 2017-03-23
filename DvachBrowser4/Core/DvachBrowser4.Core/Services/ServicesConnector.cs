using System;
using Microsoft.Extensions.DependencyInjection;

namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Коннектор сервисов.
    /// </summary>
    public sealed class ServicesConnector : IServicesInitializer, IServiceConnector
    {
        private readonly ServiceCollection _collection = new ServiceCollection();

        private IServiceProvider _provider;

        /// <summary>
        /// Конфигурировать сервисы.
        /// </summary>
        /// <param name="callbacks">Обратные вызовы.</param>
        public void ConfigureServices(params ServicesConfigureCallback[] callbacks)
        {
            lock (_collection)
            {
                foreach (var c in callbacks ?? new ServicesConfigureCallback[0])
                {
                    c?.Invoke(_collection);
                }
            }
        }

        /// <summary>
        /// Соединить сервисы.
        /// </summary>
        /// <typeparam name="T">Тип потребителя.</typeparam>
        /// <param name="consumer">Потребитель.</param>
        public void Connect<T>(T consumer) where T : IServiceConsumer
        {
            consumer.ConnectToServices(GetProvider(), true);
        }

        /// <summary>
        /// Получить провайдер.
        /// </summary>
        /// <returns>Провайдер.</returns>
        public IServiceProvider GetProvider()
        {
            lock (_collection)
            {
                return _provider ?? (_provider = new ProviderWrapper(_collection.BuildServiceProvider()));
            }
        }

        /// <summary>
        /// Перестроить провайдер.
        /// </summary>
        public void RebuildProvider()
        {
            lock (_collection)
            {
                _provider = null;
            }
        }

        private class ProviderWrapper : IServiceProvider
        {
            private readonly IServiceProvider _source;

            public ProviderWrapper(IServiceProvider source)
            {
                _source = source;
            }

            public object GetService(Type serviceType)
            {
                var r = _source.GetService(serviceType);
                var r2 = r as IServiceConsumer;
                r2?.ConnectToServices(this, false);
                return r;
            }
        }
    }
}