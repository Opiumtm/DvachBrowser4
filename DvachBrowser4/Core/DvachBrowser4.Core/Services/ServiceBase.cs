using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Базовый класс сервиса.
    /// </summary>
    public abstract class ServiceBase : IServiceConsumer
    {
        private int _isInitialized;

        /// <summary>
        /// Присоединить к сервисам.
        /// </summary>
        /// <param name="provider">Провайдер сервисов.</param>
        /// <param name="force">Форсировать повторную инициализацию.</param>
        void IServiceConsumer.ConnectToServices(IServiceProvider provider, bool force)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (Interlocked.Exchange(ref _isInitialized, 1) == 0 || force)
            {
                OnConnectToServices(provider);
            }
        }

        /// <summary>
        /// Действие по соединению с сервисами.
        /// </summary>
        /// <param name="provider">Провайдер сервисов.</param>
        protected virtual void OnConnectToServices(IServiceProvider provider)
        {
        }

        /// <summary>
        /// Установить ссылку на сервис.
        /// </summary>
        /// <typeparam name="T">Тип сервиса.</typeparam>
        /// <param name="provider">Провайдер.</param>
        /// <param name="reference">Ссылка.</param>
        protected void SetServiceReference<T>(IServiceProvider provider, ref ServiceReference<T> reference) where T : class
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            reference.Update(provider.GetService<T>());
        }
    }
}