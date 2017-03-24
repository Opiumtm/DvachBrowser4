using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Время жизни элемента XAML.
    /// </summary>
    public sealed class FrameworkElementLifetime : DispatchedLifetimeStateBase
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <param name="alreadyLoaded">Уже загружен.</param>
        public FrameworkElementLifetime(FrameworkElement element, bool alreadyLoaded)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            Dispatcher = element.Dispatcher;        
            SetHandler(element, this, alreadyLoaded);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="element">Элемент.</param>
        public FrameworkElementLifetime(FrameworkElement element)
            :this(element, false)
        {            
        }

        private static void SetHandler(FrameworkElement element, FrameworkElementLifetime obj, bool alreadyLoaded)
        {
            RoutedEventHandler loaded = (sender, e) =>
            {
                obj.UpdateLifetimeStateNoTask(LifetimeState.Active);
            };
            RoutedEventHandler[] unloaded = {null};
            unloaded[0] = (sender, e) =>
            {
                element.Loaded -= loaded;
                element.Unloaded -= unloaded[0];
                obj.UpdateLifetimeStateNoTask(LifetimeState.Disposed);
            };
            element.Loaded += loaded;
            element.Unloaded += unloaded[0];
            if (alreadyLoaded)
            {
                loaded(element, null);
            }
        }

        protected override CoreDispatcher Dispatcher { get; }

        public static implicit operator FrameworkElementLifetime(FrameworkElement element)
        {
            return new FrameworkElementLifetime(element);
        }
    }
}