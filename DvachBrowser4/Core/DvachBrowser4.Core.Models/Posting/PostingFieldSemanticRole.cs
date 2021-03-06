﻿namespace DvachBrowser4.Core.Models.Posting
{
    /// <summary>
    /// Семантическая роль поля постинга.
    /// </summary>
    public enum PostingFieldSemanticRole
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        Title,

        /// <summary>
        /// Комментарий.
        /// </summary>
        Comment,

        /// <summary>
        /// Адрес почты.
        /// </summary>
        Email,

        /// <summary>
        /// Имя постера.
        /// </summary>
        PosterName,

        /// <summary>
        /// Трипкод (1 часть).
        /// </summary>
        PosterTrip,

        /// <summary>
        /// Трипкод (2 часть).
        /// </summary>
        PosterTrip2,

        /// <summary>
        /// Иконка (для политача и подобных борд).
        /// </summary>
        Icon,

        /// <summary>
        /// Сажа.
        /// </summary>
        SageFlag,

        /// <summary>
        /// Ватермарка.
        /// </summary>
        WatermarkFlag,

        /// <summary>
        /// Флаг ОП-постера.
        /// </summary>
        OpFlag,

        /// <summary>
        /// Медиа файл.
        /// </summary>
        MediaFile,

        /// <summary>
        /// Капча.
        /// </summary>
        Captcha,

        /// <summary>
        /// Тэг треда.
        /// </summary>
        ThreadTag,
    }
}