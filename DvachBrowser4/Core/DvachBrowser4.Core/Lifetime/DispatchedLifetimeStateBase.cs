using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Базовый класс информации о времени жизни объекта c диспетчеризацией событий.
    /// </summary>
    public abstract class DispatchedLifetimeStateBase : LifetimeStateBase
    {
        /// <summary>
        /// Диспетчер.
        /// </summary>
        protected abstract CoreDispatcher Dispatcher { get; }

        /// <summary>
        /// Установить состояние времени жизни.
        /// </summary>
        /// <param name="state">Состояние.</param>
        /// <returns>Таск.</returns>
        protected override async ValueTask<Nothing> UpdateLifetimeState(LifetimeState state)
        {
            if (Dispatcher.HasThreadAccess)
            {
                await DoUpdateLifetimeState(state);
            }

            var tcs = new TaskCompletionSource<int>();
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    await DoUpdateLifetimeState(state);
                    tcs.TrySetResult(0);
                }
                catch (Exception e)
                {
                    tcs.TrySetException(e);
                }
            });
            await tcs.Task;
            return Nothing.Value;
        }
    }
}