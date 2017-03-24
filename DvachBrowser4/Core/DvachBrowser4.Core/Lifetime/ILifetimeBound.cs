using System;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Элемент с управлением времени жизни.
    /// </summary>
    public interface ILifetimeBound
    {
        /// <summary>
        /// Установить состояние.
        /// </summary>
        /// <param name="newState">Новое состояние.</param>
        /// <returns>Таск.</returns>
        Task SetLifetimeState(LifetimeState newState);

        /// <summary>
        /// Текущая привязка.
        /// </summary>
        ILifetimeBinding Binding { get; set; }
    }
}