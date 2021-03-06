using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// ������� ����� ���������� � ������� ����� ������� c ���������������� �������.
    /// </summary>
    public abstract class DispatchedLifetimeStateBase : LifetimeStateBase
    {
        /// <summary>
        /// ���������.
        /// </summary>
        protected abstract CoreDispatcher Dispatcher { get; }

        /// <summary>
        /// ���������� ��������� ������� �����.
        /// </summary>
        /// <param name="state">���������.</param>
        /// <returns>����.</returns>
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