﻿namespace DvachBrowser4.Core
{
    /// <summary>
    /// Объект, поддерживающий копирование по значению.
    /// </summary>
    /// <typeparam name="T">Тип объекта.</typeparam>
    public interface IDeepCloneable<out T>
    {
        /// <summary>
        /// Клонировать.
        /// </summary>
        /// <returns>Клон.</returns>
        T DeepClone();
    }
}