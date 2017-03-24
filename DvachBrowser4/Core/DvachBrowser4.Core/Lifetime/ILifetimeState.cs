using System;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Информация о состоянии времени жизни.
    /// </summary>
    public interface ILifetimeState
    {
        /// <summary>
        /// Состояние времени жизни.
        /// </summary>
        LifetimeState LifetimeState { get; }

        /// <summary>
        /// Состояние изменилось.
        /// </summary>
        event LifetimeStateChangedEventHandler LifetimeStateChanged;
    }
}