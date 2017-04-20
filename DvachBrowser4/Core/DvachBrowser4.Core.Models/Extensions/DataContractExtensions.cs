using System;
using System.Collections.Generic;
using System.Linq;

namespace DvachBrowser4.Core.Models.Extensions
{
    /// <summary>
    /// Расширения контрактов данных.
    /// </summary>
    public static class DataContractExtensions
    {
        private static readonly Dictionary<Type, HashSet<Type>> KnownExtensions = new Dictionary<Type, HashSet<Type>>();

        /// <summary>
        /// Добавить расширение.
        /// </summary>
        /// <typeparam name="T">Базовый тип.</typeparam>
        /// <typeparam name="TExt">Тип расширения.</typeparam>
        public static void AddExtension<T, TExt>()
            where TExt : T
        {
            lock (KnownExtensions)
            {
                if (!KnownExtensions.ContainsKey(typeof(T)))
                {
                    KnownExtensions[typeof(T)] = new HashSet<Type>();
                }
                KnownExtensions[typeof(T)].Add(typeof(TExt));
            }
        }

        /// <summary>
        /// Получить известные типы.
        /// </summary>
        /// <typeparam name="T">Базовый тип.</typeparam>
        /// <returns>Типы расширения.</returns>
        public static Type[] GetKnownTypes<T>()
        {
            lock (KnownExtensions)
            {
                if (KnownExtensions.ContainsKey(typeof(T)))
                {
                    return KnownExtensions[typeof(T)].ToArray();
                }
                return new Type[0];
            }
        }
    }
}