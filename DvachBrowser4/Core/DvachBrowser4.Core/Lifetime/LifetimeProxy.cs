using System.Threading;
using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Прокси-объект для отслеживания времени жизни объекта.
    /// </summary>
    public sealed class LifetimeProxy : LifetimeStateBase, ILifetimeBound
    {
        /// <summary>
        /// Установить состояние.
        /// </summary>
        /// <param name="newState">Новое состояние.</param>
        /// <returns>Таск.</returns>
        public ValueTask<Nothing> SetLifetimeState(LifetimeState newState)
        {
            return UpdateLifetimeState(newState);
        }

        private ILifetimeBinding _binding;

        /// <summary>
        /// Текущая привязка.
        /// </summary>
        public ILifetimeBinding Binding
        {
            get { return Interlocked.CompareExchange(ref _binding, null, null); }
            set { Interlocked.Exchange(ref _binding, value); }
        }
    }
}