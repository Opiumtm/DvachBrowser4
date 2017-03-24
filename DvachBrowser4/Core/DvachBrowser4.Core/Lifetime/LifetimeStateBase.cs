using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Базовый класс информации о времени жизни объекта.
    /// </summary>
    public abstract class LifetimeStateBase : ILifetimeState
    {
        private int _lifetimeState = (int)LifetimeState.Inactive;

        /// <summary>
        /// Состояние времени жизни.
        /// </summary>
        public LifetimeState LifetimeState => (LifetimeState) Interlocked.CompareExchange(ref _lifetimeState, 0, 0);

        /// <summary>
        /// Установить состояние времени жизни.
        /// </summary>
        /// <param name="state">Состояние.</param>
        /// <returns>Таск.</returns>
        protected virtual Task UpdateLifetimeState(LifetimeState state)
        {
            return DoUpdateLifetimeState(state);
        }

        /// <summary>
        /// Установить состояние времени жизни.
        /// </summary>
        /// <param name="state">Состояние.</param>
        /// <returns>Таск.</returns>
        protected async Task DoUpdateLifetimeState(LifetimeState state)
        {
            Interlocked.Exchange(ref _lifetimeState, (int) state);
            await InvokeLifetimeStateChanged(state);
        }

        /// <summary>
        /// Установить состояние времени жизни.
        /// </summary>
        /// <param name="state">Состояние.</param>
        protected async void UpdateLifetimeStateNoTask(LifetimeState state)
        {
            try
            {
                await UpdateLifetimeState(state);
            }
            catch
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }

        /// <summary>
        /// Вызвать событие по изменению состояния.
        /// </summary>
        /// <param name="lifetimeState">Состояние.</param>
        /// <returns>Событие.</returns>
        protected virtual async Task InvokeLifetimeStateChanged(LifetimeState lifetimeState)
        {
            LifetimeStateChangedEventHandler[] toInvoke;
            lock (_handlers)
            {
                toInvoke = _handlers.ToArray();
            }
            foreach (var handler in toInvoke)
            {
                await handler(this, lifetimeState);
            }
        }

        private readonly HashSet<LifetimeStateChangedEventHandler> _handlers = new HashSet<LifetimeStateChangedEventHandler>();

        /// <summary>
        /// Состояние изменилось.
        /// </summary>
        public event LifetimeStateChangedEventHandler LifetimeStateChanged
        {
            add
            {
                lock (_handlers)
                {
                    if (value != null)
                    {
                        _handlers.Add(value);
                    }
                }
            }
            remove
            {
                lock (_handlers)
                {
                    if (value != null)
                    {
                        _handlers.Remove(value);
                    }
                }
            }
        }
    }
}