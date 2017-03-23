namespace DvachBrowser4.Core.Lifetime
{
    /// <summary>
    /// Состояние цикла жизни.
    /// </summary>
    public enum LifetimeState
    {
        /// <summary>
        /// Не активен.
        /// </summary>
        Inactive,
        /// <summary>
        /// Активен.
        /// </summary>
        Active,
        /// <summary>
        /// Приостановлен.
        /// </summary>
        Suspended,
        /// <summary>
        /// Уничтожен (конечная фаза, дальнейшие изменения состояния невозможны).
        /// </summary>
        Disposed
    }
}