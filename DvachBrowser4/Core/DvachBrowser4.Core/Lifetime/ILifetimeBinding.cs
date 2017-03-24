using System;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Привязка времени жизни.
    /// </summary>
    public interface ILifetimeBinding
    {
        /// <summary>
        /// Привязать.
        /// </summary>
        void Bind();

        /// <summary>
        /// Отвязать.
        /// </summary>
        void Unbind();

        /// <summary>
        /// Привязано.
        /// </summary>
        bool IsBound { get; }

        /// <summary>
        /// Привязан.
        /// </summary>
        event EventHandler OnBound;

        /// <summary>
        /// Отвязан.
        /// </summary>
        event EventHandler OnUnbound;
    }
}