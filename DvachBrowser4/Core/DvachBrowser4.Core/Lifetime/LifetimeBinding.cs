using System;
using System.Diagnostics;
using System.Threading;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Привязка времени жизни.
    /// </summary>
    /// <typeparam name="TSrc">Тип исходного объекта.</typeparam>
    /// <typeparam name="TDst">Целевой объект.</typeparam>
    public sealed class LifetimeBinding<TSrc, TDst> : ILifetimeBinding
        where TSrc: ILifetimeState
        where TDst: ILifetimeBound
    {
        private Action _bind;
        private Action _unbind;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="src">Исходный объект.</param>
        /// <param name="dst">Целевой объект.</param>
        public LifetimeBinding(TSrc src, TDst dst)
        {
            CreateHandlers(src, dst, this);
        }

        private static void CreateHandlers(TSrc src, TDst dst, LifetimeBinding<TSrc, TDst> obj)
        {
            LifetimeStateChangedEventHandler lifetimeChanged = async (sender, e) =>
            {
                try
                {
                    await dst.SetLifetimeState(e);
                    if (e == LifetimeState.Disposed)
                    {
                        obj.Unbind();
                    }
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
                return Nothing.Value;
            };
            obj._bind = () =>
            {
                src.LifetimeStateChanged += lifetimeChanged;
            };
            obj._unbind = () =>
            {
                src.LifetimeStateChanged -= lifetimeChanged;
                obj._bind = null;
                obj._unbind = null;
            };
        }

        /// <summary>
        /// Привязать.
        /// </summary>
        public void Bind()
        {
            if (Interlocked.Exchange(ref _isBound, 1) == 0)
            {
                if (_bind == null)
                {
                    return;
                }
                _bind();
                OnBound?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Отвязать.
        /// </summary>
        public void Unbind()
        {
            if (Interlocked.Exchange(ref _isBound, 0) == 1)
            {
                if (_unbind == null)
                {
                    return;
                }
                _unbind();
                OnUnbound?.Invoke(this, EventArgs.Empty);
            }
        }

        private int _isBound;

        /// <summary>
        /// Привязано.
        /// </summary>
        public bool IsBound => Interlocked.CompareExchange(ref _isBound, 0, 0) != 0;

        /// <summary>
        /// Привязан.
        /// </summary>
        public event EventHandler OnBound;

        /// <summary>
        /// Отвязан.
        /// </summary>
        public event EventHandler OnUnbound;
    }
}