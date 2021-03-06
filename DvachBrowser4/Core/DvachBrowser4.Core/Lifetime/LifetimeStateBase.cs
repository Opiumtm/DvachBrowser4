using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// ������� ����� ���������� � ������� ����� �������.
    /// </summary>
    public abstract class LifetimeStateBase : ILifetimeState
    {
        private int _lifetimeState = (int)LifetimeState.Inactive;

        /// <summary>
        /// ��������� ������� �����.
        /// </summary>
        public LifetimeState LifetimeState => (LifetimeState) Interlocked.CompareExchange(ref _lifetimeState, 0, 0);

        /// <summary>
        /// ���������� ��������� ������� �����.
        /// </summary>
        /// <param name="state">���������.</param>
        /// <returns>����.</returns>
        protected virtual ValueTask<Nothing> UpdateLifetimeState(LifetimeState state)
        {
            return DoUpdateLifetimeState(state);
        }

        /// <summary>
        /// ���������� ��������� ������� �����.
        /// </summary>
        /// <param name="state">���������.</param>
        /// <returns>����.</returns>
        protected async ValueTask<Nothing> DoUpdateLifetimeState(LifetimeState state)
        {
            Interlocked.Exchange(ref _lifetimeState, (int) state);
            return await InvokeLifetimeStateChanged(state);
        }

        /// <summary>
        /// ���������� ��������� ������� �����.
        /// </summary>
        /// <param name="state">���������.</param>
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
        /// ������� ������� �� ��������� ���������.
        /// </summary>
        /// <param name="lifetimeState">���������.</param>
        /// <returns>�������.</returns>
        protected virtual async ValueTask<Nothing> InvokeLifetimeStateChanged(LifetimeState lifetimeState)
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
            return Nothing.Value;
        }

        private readonly HashSet<LifetimeStateChangedEventHandler> _handlers = new HashSet<LifetimeStateChangedEventHandler>();

        /// <summary>
        /// ��������� ����������.
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