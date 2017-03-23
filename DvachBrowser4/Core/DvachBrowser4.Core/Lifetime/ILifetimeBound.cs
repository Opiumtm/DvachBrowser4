using System;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Объект, имеющий управление циклом жизни.
    /// </summary>
    public interface ILifetimeBound
    {
        /// <summary>
        /// Установить состояние цикла жизни объекта.
        /// </summary>
        /// <param name="state">Состояние.</param>
        /// <returns>Таск.</returns>
        Task SetLifetimeState(LifetimeState state);

        /// <summary>
        /// Состоянике цикла жизни.
        /// </summary>
        LifetimeState LifetimeState { get; }

        /// <summary>
        /// Можно устанавливать состояние.
        /// </summary>
        bool CanBindState { get; }

        /// <summary>
        /// Состояние изменилось.
        /// </summary>
        event EventHandler<LifetimeState> StateChanged;

        /// <summary>
        /// Присоединить к объекту.
        /// </summary>
        /// <param name="sourceObject">Исходный объект.</param>
        void Bind(object sourceObject);

        /// <summary>
        /// Отсоединить от объекта.
        /// </summary>
        /// <param name="sourceObject">Исходный объект.</param>
        void Unbind(object sourceObject);
    }
}