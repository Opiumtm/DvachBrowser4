using System;
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Класс-помощник для связи жизненного цикла объектов.
    /// </summary>
    public static class LifetimeConnectionHelper
    {
        /// <summary>
        /// Установить зависимость времени жизни.
        /// </summary>
        /// <typeparam name="TSrc">Тип исходного объекта.</typeparam>
        /// <typeparam name="TDst">Тип целевого объекта.</typeparam>
        /// <param name="dst">Целевой объект.</param>
        /// <param name="src">Исходный объект.</param>
        public static void DependOn<TSrc, TDst>(this TDst dst, TSrc src)
            where TSrc : ILifetimeBound
            where TDst : ILifetimeBound
        {
            if (!dst.CanBindState)
            {
                throw new ArgumentException("Целевой объект не поддерживает зависимость от внешнего состояния");
            }
            dst.Bind(src);
            var handler = CreateHandler(dst);
            src.StateChanged += handler;
            handler(src, src.LifetimeState);
        }

        /// <summary>
        /// Установить зависимость времени жизни от элемента XAML.
        /// </summary>
        /// <typeparam name="TDst">Тип целевого объекта.</typeparam>
        /// <param name="dst">Целевой объект.</param>
        /// <param name="src">Исходный объект.</param>
        /// <param name="alreadyLoaded">Элемент уже загружен.</param>
        public static void DependOn<TDst>(this TDst dst, FrameworkElement src, bool alreadyLoaded = false)
            where TDst : ILifetimeBound
        {
            if (src == null) throw new ArgumentNullException(nameof(src));
            if (!dst.CanBindState)
            {
                throw new ArgumentException("Целевой объект не поддерживает зависимость от внешнего состояния");
            }
            dst.Bind(src);
            var handler = CreateFrameworkHandler(dst);
            src.Loaded += handler.loaded;
            src.Unloaded += handler.unloaded;
            if (alreadyLoaded)
            {
                handler.loaded(src, null);
            }
        }

        /// <summary>
        /// Установить зависимость времени жизни от элемента XAML.
        /// </summary>
        /// <typeparam name="TDst">Тип целевого объекта.</typeparam>
        /// <param name="dst">Целевой объект.</param>
        /// <param name="src">Исходный объект.</param>
        /// <param name="application">Приложение.</param>
        /// <param name="alreadyLoaded">Элемент уже загружен.</param>
        public static void DependOn<TDst>(this TDst dst, FrameworkElement src, Application application, bool alreadyLoaded = false)
            where TDst : ILifetimeBound
        {
            if (!dst.CanBindState)
            {
                throw new ArgumentException("Целевой объект не поддерживает зависимость от внешнего состояния");
            }
            dst.Bind(src);
            var handler = CreateFrameworkHandler(dst, application);
            src.Loaded += handler.loaded;
            src.Unloaded += handler.unloaded;
            application.Suspending += handler.suspending;
            application.Resuming += handler.resuming;
            if (alreadyLoaded)
            {
                handler.loaded(src, null);
            }
        }

        private static EventHandler<LifetimeState> CreateHandler<TDst>(TDst dst)
            where TDst : ILifetimeBound
        {
            EventHandler<LifetimeState> handler = null;

            handler = async (sender, lifetimeState) =>
            {
                try
                {
                    await dst.SetLifetimeState(lifetimeState);
                    if (lifetimeState == LifetimeState.Disposed)
                    {
                        var src = (ILifetimeBound)sender;
                        dst.Unbind(src);
                        src.StateChanged -= handler;
                    }
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            return handler;
        }

        private static (RoutedEventHandler loaded, RoutedEventHandler unloaded) CreateFrameworkHandler<TDst>(TDst dst)
            where TDst : ILifetimeBound
        {
            RoutedEventHandler[] unloaded = {null};

            RoutedEventHandler loaded = async (sender, e) =>
            {
                try
                {
                    await dst.SetLifetimeState(LifetimeState.Active);
                }
                catch 
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            unloaded[0] = async (sender, e) =>
            {
                try
                {
                    var f = (FrameworkElement)sender;
                    await dst.SetLifetimeState(LifetimeState.Disposed);
                    dst.Unbind(dst);
                    f.Loaded -= loaded;
                    f.Unloaded -= unloaded[0];
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            return (loaded, unloaded[0]);
        }

        private static (RoutedEventHandler loaded, RoutedEventHandler unloaded, SuspendingEventHandler suspending, EventHandler<object> resuming) CreateFrameworkHandler<TDst>(TDst dst, Application application)
            where TDst : ILifetimeBound
        {
            RoutedEventHandler[] unloaded = { null };

            RoutedEventHandler loaded = async (sender, e) =>
            {
                try
                {
                    await dst.SetLifetimeState(LifetimeState.Active);
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            SuspendingEventHandler suspending = async (sender, e) =>
            {
                try
                {
                    var deferral = e.SuspendingOperation.GetDeferral();
                    try
                    {
                        await dst.SetLifetimeState(LifetimeState.Suspended);
                    }
                    finally
                    {
                        deferral.Complete();
                    }
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            EventHandler<object> resuming = async (sender, e) =>
            {
                try
                {
                    await dst.SetLifetimeState(LifetimeState.Active);
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            unloaded[0] = async (sender, e) =>
            {
                try
                {
                    var f = (FrameworkElement)sender;
                    await dst.SetLifetimeState(LifetimeState.Disposed);
                    dst.Unbind(dst);
                    f.Loaded -= loaded;
                    f.Unloaded -= unloaded[0];
                    application.Suspending -= suspending;
                    application.Resuming -= resuming;
                }
                catch
                {
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                }
            };

            return (loaded, unloaded[0], suspending, resuming);
        }
    }
}