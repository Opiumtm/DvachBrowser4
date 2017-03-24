namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Класс-помощник для связи времени жизни объектов.
    /// </summary>
    public static class LifetimeHelper
    {
        /// <summary>
        /// Установить зависимость времени жизни.
        /// </summary>
        /// <typeparam name="TSrc">Исходный объект.</typeparam>
        /// <typeparam name="TDst">Целевой объект.</typeparam>
        /// <param name="dst">Целевой объект.</param>
        /// <param name="source">Исходный объект.</param>
        public static void DependOn<TSrc, TDst>(this TDst dst, TSrc source)
            where TSrc : ILifetimeState
            where TDst : ILifetimeBound
        {
            dst.Binding?.Unbind();
            var binding = new LifetimeBinding<TSrc, TDst>(source, dst);
            dst.Binding = binding;
            binding.Bind();
        }

        /// <summary>
        /// Отменить зависимость времени жизни.
        /// </summary>
        /// <typeparam name="TDst">Целевой объект.</typeparam>
        /// <param name="dst">Целевой объект.</param>
        public static void CancelDependency<TDst>(this TDst dst)
            where TDst : ILifetimeBound
        {
            dst.Binding?.Unbind();
            dst.Binding = null;
        }
    }
}