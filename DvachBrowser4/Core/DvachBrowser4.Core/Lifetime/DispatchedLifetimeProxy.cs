using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Прокси-объект для отслеживания времени жизни объекта с диспетчеризацией событий.
    /// </summary>
    public sealed class DispatchedLifetimeProxy : DispatchedLifetimeStateBase, ILifetimeBound
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dispatcher">Диспетчер.</param>
        public DispatchedLifetimeProxy(CoreDispatcher dispatcher)
        {
            if (dispatcher == null) throw new ArgumentNullException(nameof(dispatcher));
            Dispatcher = dispatcher;
        }

        /// <summary>
        /// Установить состояние.
        /// </summary>
        /// <param name="newState">Новое состояние.</param>
        /// <returns>Таск.</returns>
        public ValueTask<Nothing> SetLifetimeState(LifetimeState newState)
        {
            return UpdateLifetimeState(newState);
        }

        private ILifetimeBinding _binding;

        /// <summary>
        /// Текущая привязка.
        /// </summary>
        public ILifetimeBinding Binding
        {
            get { return Interlocked.CompareExchange(ref _binding, null, null); }
            set { Interlocked.Exchange(ref _binding, value); }
        }

        /// <summary>
        /// Диспетчер.
        /// </summary>
        protected override CoreDispatcher Dispatcher { get; }
    }
}