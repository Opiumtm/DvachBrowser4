using System;
using System.Diagnostics;
using System.Threading;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Время жизни элемента XAML.
    /// </summary>
    public sealed class FrameworkElementLifetimeWithGlobalSuspend : DispatchedLifetimeStateBase
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="alreadyLoaded">Уже загружен.</param>
        /// <param name="application">Приложение.</param>
        public FrameworkElementLifetimeWithGlobalSuspend(FrameworkElement element, Application application, bool alreadyLoaded)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (application == null) throw new ArgumentNullException(nameof(application));
            Dispatcher = element.Dispatcher;
            SetHandler(element, application, this, alreadyLoaded);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="application">Приложение.</param>
        public FrameworkElementLifetimeWithGlobalSuspend(FrameworkElement element, Application application)
            : this(element, application, false)
        {
        }

        private static bool CheckHaveBackgroundEvents()
        {
            return ApiInformation.IsEventPresent("Windows.UI.Xaml.Application", nameof(Application.EnteredBackground));
        }

        private static readonly Lazy<bool> HaveBackgroundEvents = new Lazy<bool>(CheckHaveBackgroundEvents);

        private static void SetHandler(FrameworkElement element, Application application, FrameworkElementLifetimeWithGlobalSuspend obj, bool alreadyLoaded)
        {
            if (!HaveBackgroundEvents.Value)
            {
                int loadedState = 0;
                RoutedEventHandler loaded = (sender, e) =>
                {
                    Interlocked.Exchange(ref loadedState, 1);
                    obj.UpdateLifetimeStateNoTask(LifetimeState.Active);
                };
                SuspendingEventHandler suspending = async (sender, e) =>
                {
                    var deferral = e.SuspendingOperation.GetDeferral();
                    try
                    {
                        await obj.UpdateLifetimeState(LifetimeState.Suspended);
                    }
                    catch
                    {
                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
                    }
                    finally
                    {
                        deferral.Complete();
                    }
                };
                EventHandler<object> resuming = (sender, e) =>
                {
                    if (obj.LifetimeState == LifetimeState.Suspended)
                    {
                        if (Interlocked.CompareExchange(ref loadedState, 0, 0) != 0)
                        {
                            obj.UpdateLifetimeStateNoTask(LifetimeState.Active);
                        }
                        else
                        {
                            obj.UpdateLifetimeStateNoTask(LifetimeState.Inactive);
                        }
                    }
                };
                RoutedEventHandler[] unloaded = { null };
                unloaded[0] = (sender, e) =>
                {
                    element.Loaded -= loaded;
                    element.Unloaded -= unloaded[0];
                    application.Suspending -= suspending;
                    application.Resuming -= resuming;
                    obj.UpdateLifetimeStateNoTask(LifetimeState.Disposed);
                };
                element.Loaded += loaded;
                element.Unloaded += unloaded[0];
                application.Suspending += suspending;
                application.Resuming += resuming;
                if (alreadyLoaded)
                {
                    loaded(element, null);
                }
            }
            else
            {
                int loadedState = 0;
                RoutedEventHandler loaded = (sender, e) =>
                {
                    Interlocked.Exchange(ref loadedState, 1);
                    obj.UpdateLifetimeStateNoTask(LifetimeState.Active);
                };
                EnteredBackgroundEventHandler enteredBackground = async (sender, e) =>
                {
                    var deferral = e.GetDeferral();
                    try
                    {
                        await obj.UpdateLifetimeState(LifetimeState.Suspended);
                    }
                    catch
                    {
                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
                    }
                    finally
                    {
                        deferral.Complete();
                    }
                };
                LeavingBackgroundEventHandler leavingBackground = async (sender, e) =>
                {
                    if (obj.LifetimeState == LifetimeState.Suspended)
                    {
                        var deferral = e.GetDeferral();
                        try
                        {
                            if (Interlocked.CompareExchange(ref loadedState, 0, 0) != 0)
                            {
                                await obj.UpdateLifetimeState(LifetimeState.Active);
                            }
                            else
                            {
                                await obj.UpdateLifetimeState(LifetimeState.Inactive);
                            }
                        }
                        catch
                        {
                            if (Debugger.IsAttached)
                            {
                                Debugger.Break();
                            }
                        }
                        finally
                        {
                            deferral.Complete();
                        }
                    }
                };
                RoutedEventHandler[] unloaded = { null };
                unloaded[0] = (sender, e) =>
                {
                    element.Loaded -= loaded;
                    element.Unloaded -= unloaded[0];
                    application.EnteredBackground -= enteredBackground;
                    application.LeavingBackground -= leavingBackground;
                    obj.UpdateLifetimeStateNoTask(LifetimeState.Disposed);
                };
                element.Loaded += loaded;
                element.Unloaded += unloaded[0];
                application.EnteredBackground += enteredBackground;
                application.LeavingBackground += leavingBackground;
                if (alreadyLoaded)
                {
                    loaded(element, null);
                }
            }
        }

        protected override CoreDispatcher Dispatcher { get; }
    }
}