﻿using System;

namespace DvachBrowser4.Core.Models.Links
{
    /// <summary>
    /// Тип ссылки.
    /// </summary>
    [Flags]
    public enum BoardLinkKind : int
    {
        /// <summary>
        /// Страница борды.
        /// </summary>
        BoardPage = 0x0001,

        /// <summary>
        /// Тред.
        /// </summary>
        Thread = 0x0002,

        /// <summary>
        /// Пост.
        /// </summary>
        Post = 0x0004,

        /// <summary>
        /// Медиа.
        /// </summary>
        Media = 0x0008,

        /// <summary>
        /// Ютуба.
        /// </summary>
        Youtube = 0x0010,

        /// <summary>
        /// Часть треда.
        /// </summary>
        PartialThread = 0x0020,

        /// <summary>
        /// Тэг треда.
        /// </summary>
        ThreadTag = 0x0040,

        /// <summary>
        /// Каталог.
        /// </summary>
        Catalog = 0x0080,

        /// <summary>
        /// Прочее.
        /// </summary>
        Other = 0x8000
    }
}