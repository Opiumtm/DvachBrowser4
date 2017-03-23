using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DvachBrowser4.Core.Services
{
    /// <summary>
    /// Ссылка на сервис.
    /// </summary>
    public struct ServiceReference<T> where T : class
    {
        private T _reference;

        /// <summary>
        /// Обновить ссылку.
        /// </summary>
        /// <param name="newReference">Новая ссылка.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Update(T newReference)
        {
            Interlocked.Exchange(ref _reference, newReference);
        }

        /// <summary>
        /// Ссылка на сервис.
        /// </summary>
        public T Value
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return Interlocked.CompareExchange(ref _reference, null, null);
            }
        }

        /// <summary>
        /// Бросить исключение, если ссылка пустая.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ThrowIfNull()
        {
            if (Value == null)
            {
                throw new NotImplementedException($"Не инициализирован обязательный сервис {typeof(T).FullName}");
            }
        }
    }
}