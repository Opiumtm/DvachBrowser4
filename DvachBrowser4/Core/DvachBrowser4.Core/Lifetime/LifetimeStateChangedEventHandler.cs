using System.Threading.Tasks;

namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Обработчик события по изменившемуся состоянию.
    /// </summary>
    /// <param name="sender">Отправитель.</param>
    /// <param name="lifetimeState">Состояние.</param>
    /// <returns>Таск.</returns>
    public delegate ValueTask<Nothing> LifetimeStateChangedEventHandler(object sender, LifetimeState lifetimeState);
}