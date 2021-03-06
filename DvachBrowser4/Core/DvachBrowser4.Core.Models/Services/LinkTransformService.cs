﻿using System;
using System.Collections.Generic;
using System.Linq;
using DvachBrowser4.Core.Models.Links;
using DvachBrowser4.Core.Services;

namespace DvachBrowser4.Core.Models.Services
{
    /// <summary>
    /// Сервис изменения ссылок.
    /// </summary>
    internal sealed class LinkTransformService : ServiceBase, ILinkTransformService
    {
        /// <summary>
        /// Получить ссылку на тред из ссылки на часть треда.
        /// </summary>
        /// <param name="link">Ссылка на часть треда.</param>
        /// <returns>Ссылка на тред.</returns>
        public BoardLinkBase ThreadLinkFromThreadPartLink(BoardLinkBase link)
        {
            if (link is ThreadPartLink)
            {
                var l = link as ThreadLink;
                return new ThreadLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Thread = l.Thread
                };
            }
            if (link is ThreadLink)
            {
                var l = link as ThreadLink;
                return new ThreadLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Thread = l.Thread
                };
            }
            return null;
        }

        /// <summary>
        /// Получить ссылку на часть треда из ссылки на тред.
        /// </summary>
        /// <param name="threadLink">Ссылка на тред.</param>
        /// <param name="lastPostLink">Ссылка на последний пост.</param>
        /// <returns>Ссылка на часть треда.</returns>
        public BoardLinkBase ThreadPartLinkFromThreadLink(BoardLinkBase threadLink, BoardLinkBase lastPostLink)
        {
            if (threadLink is ThreadLink && lastPostLink is PostLink)
            {
                var l = threadLink as ThreadLink;
                var pl = lastPostLink as PostLink;
                if (string.Equals(l.Engine, pl.Engine, StringComparison.OrdinalIgnoreCase) && string.Equals(l.Board, pl.Board, StringComparison.OrdinalIgnoreCase) && l.Thread == pl.Thread)
                {
                    return new ThreadPartLink()
                    {
                        Engine = l.Engine,
                        Board = l.Board,
                        Thread = l.Thread,
                        FromPost = pl.Post
                    };
                }
            }
            return null;
        }

        /// <summary>
        /// Получить ссылку на страницу борды.
        /// </summary>
        /// <param name="link">Ссылка на борду или страницу борды.</param>
        /// <returns>Ссылка на страницу борды.</returns>
        public BoardLinkBase BoardPageLinkFromBoardLink(BoardLinkBase link)
        {
            if (link is BoardPageLink)
            {
                var l = link as BoardPageLink;
                return new BoardPageLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Page = l.Page
                };
            }
            if (link is BoardLink)
            {
                var l = link as BoardLink;
                return new BoardPageLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Page = 0
                };
            }
            return null;
        }

        /// <summary>
        /// Установить страницу борды.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <param name="page">Страница борды.</param>
        /// <returns>Ссылка на страницу борды.</returns>
        public BoardLinkBase SetBoardPage(BoardLinkBase link, int page)
        {
            if (link is BoardPageLink)
            {
                var l = link as BoardPageLink;
                return new BoardPageLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Page = page
                };
            }
            if (link is BoardLink)
            {
                var l = link as BoardLink;
                return new BoardPageLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Page = page
                };
            }
            return null;
        }

        /// <summary>
        /// Получить ссылку на борду из ссылки на страницу борды.
        /// </summary>
        /// <param name="link">Ссылка на борду или страницу борды.</param>
        /// <returns>Ссылка на борду.</returns>
        public BoardLinkBase BoardLinkFromBoardPageLink(BoardLinkBase link)
        {
            if (link is BoardPageLink)
            {
                var l = link as BoardPageLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is BoardLink)
            {
                var l = link as BoardLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            return null;
        }

        /// <summary>
        /// Получить ссылку на борду из любой ссылки.
        /// </summary>
        /// <param name="link">Ссылка на борду или страницу борды.</param>
        /// <returns>Ссылка на борду.</returns>
        public BoardLinkBase BoardLinkFromAnyLink(BoardLinkBase link)
        {
            if (link is BoardPageLink)
            {
                var l = link as BoardPageLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is BoardLink)
            {
                var l = link as BoardLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is ThreadLink)
            {
                var l = link as ThreadLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is PostLink)
            {
                var l = link as PostLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is BoardMediaLink)
            {
                var l = link as BoardMediaLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is ThreadTagLink)
            {
                var l = link as ThreadTagLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            if (link is BoardCatalogLink)
            {
                var l = link as BoardCatalogLink;
                return new BoardLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                };
            }
            return null;
        }

        /// <summary>
        /// Получить страницу борды.
        /// </summary>
        /// <param name="link">Ссылка на борду или страницу борды.</param>
        /// <returns>Страница борды.</returns>
        public int GetBoardPage(BoardLinkBase link)
        {
            if (link is BoardPageLink)
            {
                var l = link as BoardPageLink;
                return l.Page;
            }
            return 0;
        }

        /// <summary>
        /// Получить номер поста.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Номер треда.</returns>
        public int? GetPostNum(BoardLinkBase link)
        {
            if (link is ThreadLink)
            {
                var l = link as ThreadLink;
                return l.Thread;
            }
            if (link is PostLink)
            {
                var l = link as PostLink;
                return l.Post;
            }
            return null;
        }

        /// <summary>
        /// Получить средство сравнения ссылок.
        /// </summary>
        /// <returns>Средство сравнения ссылок.</returns>
        public IComparer<BoardLinkBase> GetLinkComparer()
        {
            return LinkComparer.Instance;
        }

        /// <summary>
        /// Строка для отображения ссылки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Строка.</returns>
        public string GetLinkDisplayString(BoardLinkBase link)
        {
            if (link.GetType() == typeof (BoardLink))
            {
                var l = (BoardLink) link;
                return string.Format("/{0}/", l.Board);
            }
            if (link.GetType() == typeof(BoardCatalogLink))
            {
                var l = (BoardCatalogLink)link;
                return string.Format("/{0}/#cat", l.Board);
            }
            if (link.GetType() == typeof(BoardPageLink))
            {
                var l = (BoardPageLink)link;
                return string.Format("/{0}/", l.Board);
            }
            if (link.GetType() == typeof(ThreadLink))
            {
                var l = (ThreadLink)link;
                return string.Format("/{0}/{1}", l.Board, l.Thread);
            }
            if (link.GetType() == typeof(ThreadPartLink))
            {
                var l = (ThreadPartLink)link;
                return string.Format("/{0}/{1}", l.Board, l.Thread);
            }
            if (link.GetType() == typeof(ThreadTagLink))
            {
                var l = (ThreadTagLink)link;
                return string.Format("/{0}/tags/#{1}", l.Board, l.Tag);
            }
            if (link.GetType() == typeof(PostLink))
            {
                var l = (PostLink)link;
                return string.Format("/{0}/{1}#{2}", l.Board, l.Thread, l.Post);
            }
            if (link.GetType() == typeof(BoardMediaLink))
            {
                var l = (BoardMediaLink)link;
                return string.Format("/{0}/{1}", l.Board, l.RelativeUri.RemoveStartingSlash());
            }
            if (link.GetType() == typeof(MediaLink))
            {
                var l = (MediaLink)link;
                return l.RelativeUri;
            }
            if (link.GetType() == typeof(YoutubeLink))
            {
                var l = (YoutubeLink)link;
                return string.Format("youtube:{0}", l.YoutubeId);
            }
            if (link.GetType() == typeof(RootLink))
            {
                var l = (RootLink)link;
                if (CoreConstants.Engine.Makaba.Equals(l.Engine, StringComparison.OrdinalIgnoreCase))
                {
                    return "2ch://";
                }
                else
                {
                    return (l.Engine ?? "").ToLower();
                }
            }
            return "";
        }

        /// <summary>
        /// Строка для отображения обратной ссылки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Строка.</returns>
        public string GetBackLinkDisplayString(BoardLinkBase link)
        {
            if (link.GetType() == typeof(BoardLink))
            {
                var l = (BoardLink)link;
                return string.Format(">>/{0}/", l.Board);
            }
            if (link.GetType() == typeof(BoardPageLink))
            {
                var l = (BoardPageLink)link;
                return string.Format(">>/{0}/", l.Board);
            }
            if (link.GetType() == typeof(BoardCatalogLink))
            {
                var l = (BoardCatalogLink)link;
                return string.Format(">>/{0}/#cat", l.Board);
            }
            if (link.GetType() == typeof(ThreadLink))
            {
                var l = (ThreadLink)link;
                return string.Format(">>{0}", l.Thread);
            }
            if (link.GetType() == typeof(ThreadPartLink))
            {
                var l = (ThreadPartLink)link;
                return string.Format(">>{0}", l.Thread);
            }
            if (link.GetType() == typeof(ThreadTagLink))
            {
                var l = (ThreadTagLink)link;
                return string.Format(">>/{0}/tags/#{1}", l.Board, l.Tag);
            }
            if (link.GetType() == typeof(PostLink))
            {
                var l = (PostLink)link;
                return string.Format(">>{0}", l.Post);
            }
            if (link.GetType() == typeof(BoardMediaLink))
            {
                var l = (BoardMediaLink)link;
                return string.Format(">>/{0}/{1}", l.Board, l.RelativeUri.RemoveStartingSlash());
            }
            if (link.GetType() == typeof(MediaLink))
            {
                var l = (MediaLink)link;
                return ">>" + l.RelativeUri;
            }
            if (link.GetType() == typeof(YoutubeLink))
            {
                var l = (YoutubeLink)link;
                return string.Format(">>youtube:{0}", l.YoutubeId);
            }
            if (link.GetType() == typeof(RootLink))
            {
                var l = (RootLink)link;
                if (CoreConstants.Engine.Makaba.Equals(l.Engine, StringComparison.OrdinalIgnoreCase))
                {
                    return ">>2ch:";
                }
                else
                {
                    return string.Format(">>{0}:", (l.Engine ?? "").ToLower());
                }
            }
            return ">>[?]";
        }

        /// <summary>
        /// Строка номера поста.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Строка.</returns>
        public string GetPostNumberDisplayString(BoardLinkBase link)
        {
            if (link is ThreadLink)
            {
                var l = link as ThreadLink;
                return l.Thread.ToString();
            }
            if (link is PostLink)
            {
                var l = link as PostLink;
                return l.Post.ToString();
            }
            return "[?]";
        }

        /// <summary>
        /// Ссылка из этого треда.
        /// </summary>
        /// <param name="threadLink">Ссылка на тред.</param>
        /// <param name="postLink">Ссылка на пост.</param>
        /// <returns>Результат проверки.</returns>
        public bool IsThisTread(BoardLinkBase threadLink, BoardLinkBase postLink)
        {
            var tlink = threadLink as ThreadLink;
            var plink = postLink as PostLink;
            if (tlink != null && plink != null)
            {
                if (StringComparer.OrdinalIgnoreCase.Equals(tlink.Engine, plink.Engine) && StringComparer.OrdinalIgnoreCase.Equals(tlink.Board, plink.Board) && tlink.Thread == plink.Thread)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Получить ссылку на пост по номеру поста.
        /// </summary>
        /// <param name="threadLink">Ссылка на тред.</param>
        /// <param name="postNum">Номер поста.</param>
        /// <returns>Ссылка на пост (null, если это невозможно).</returns>
        public BoardLinkBase GetPostLinkByNum(BoardLinkBase threadLink, int postNum)
        {
            var tlink = threadLink as ThreadLink;
            if (tlink == null)
            {
                return null;
            }
            return new PostLink()
            {
                Board = tlink.Board,
                Engine = tlink.Engine,
                Thread = tlink.Thread,
                Post = postNum
            };
        }

        /// <summary>
        /// Получить ссылку на пост по ссылке на тред.
        /// </summary>
        /// <param name="threadLink">Ссылка на тред.</param>
        /// <returns>Ссылка на пост (null, если это невозможно).</returns>
        public BoardLinkBase GetRootPostLink(BoardLinkBase threadLink)
        {
            var tlink = threadLink as ThreadLink;
            if (tlink == null)
            {
                return null;
            }
            return new PostLink()
            {
                Board = tlink.Board,
                Engine = tlink.Engine,
                Thread = tlink.Thread,
                Post = tlink.Thread
            };
        }

        /// <summary>
        /// Получить ссылку на каталог из любой сслыки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Ссылка на каталог.</returns>
        public BoardLinkBase GetCatalogLinkFromAnyLink(BoardLinkBase link)
        {
            if (link is BoardCatalogLink)
            {
                var l = (BoardCatalogLink) link;
                return new BoardCatalogLink()
                {
                    Engine = l.Engine,
                    Board = l.Board,
                    Sort = l.Sort
                };
            }
            var boardLink = BoardLinkFromAnyLink(link) as BoardLink;
            if (boardLink == null)
            {
                return null;
            }
            return new BoardCatalogLink()
            {
                Engine = boardLink.Engine,
                Board = boardLink.Board,
                Sort = BoardCatalogSort.Bump
            };
        }

        /// <summary>
        /// Получить ссылку на каталог из любой сслыки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <param name="sort">Режим сортировки.</param>
        /// <returns>Ссылка на каталог.</returns>
        public BoardLinkBase GetCatalogLinkFromAnyLink(BoardLinkBase link, BoardCatalogSort sort)
        {
            var boardLink = BoardLinkFromAnyLink(link) as BoardLink;
            if (boardLink == null)
            {
                return null;
            }
            return new BoardCatalogLink()
            {
                Engine = boardLink.Engine,
                Board = boardLink.Board,
                Sort = sort
            };
        }

        /// <summary>
        /// Получить ссылку на тэг из ссылки на борду.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <param name="tag">Тэг.</param>
        /// <returns>Ссылка на тэг.</returns>
        public BoardLinkBase GetThreadTagLinkFromBoardLink(BoardLinkBase link, string tag)
        {
            var boardLink = BoardLinkFromAnyLink(link) as BoardLink;
            if (boardLink == null)
            {
                return null;
            }
            return new ThreadTagLink()
            {
                Engine = boardLink.Engine,
                Board = boardLink.Board,
                Tag = tag ?? ""
            };
        }

        /// <summary>
        /// Короткое имя борды.
        /// </summary>
        /// <param name="boardLink">Ссылка на борду.</param>
        /// <returns>Короткое имя.</returns>
        public string GetBoardShortName(BoardLinkBase boardLink)
        {
            var blink = boardLink as BoardLink;
            if (blink != null)
            {
                return blink.Board?.ToLowerInvariant();
            }
            var blink2 = boardLink as BoardPageLink;
            if (blink2 != null)
            {
                return blink2.Board?.ToLowerInvariant();
            }
            var tlink = boardLink as ThreadLink;
            if (tlink != null)
            {
                return tlink.Board?.ToLowerInvariant();
            }
            var plink = boardLink as PostLink;
            if (plink != null)
            {
                return plink.Board?.ToLowerInvariant();
            }
            var tglink = boardLink as ThreadTagLink;
            if (tglink != null)
            {
                return tglink.Board?.ToLowerInvariant();
            }
            var clink = boardLink as BoardCatalogLink;
            if (clink != null)
            {
                return clink.Board?.ToLowerInvariant();
            }
            return null;
        }

        /// <summary>
        /// Получить ссылку на тред из любой ссылки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Ссылка на тред.</returns>
        public BoardLinkBase GetThreadLinkFromAnyLink(BoardLinkBase link)
        {
            var tlink = link as ThreadLink;
            if (tlink != null)
            {
                return new ThreadLink()
                {
                    Engine = tlink.Engine,
                    Board = tlink.Board,
                    Thread = tlink.Thread
                };
            }
            var plink = link as PostLink;
            if (plink != null)
            {
                return new ThreadLink()
                {
                    Engine = plink.Engine,
                    Board = plink.Board,
                    Thread = plink.Thread
                };
            }
            return null;
        }

        /// <summary>
        /// Получить ссылку на пост из любой ссылки.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Ссылка на пост.</returns>
        public BoardLinkBase GetPostLinkFromAnyLink(BoardLinkBase link)
        {
            var tlink = link as ThreadLink;
            if (tlink != null)
            {
                return new PostLink()
                {
                    Engine = tlink.Engine,
                    Board = tlink.Board,
                    Thread = tlink.Thread,
                    Post = tlink.Thread
                };
            }
            var plink = link as PostLink;
            if (plink != null)
            {
                return new PostLink()
                {
                    Engine = plink.Engine,
                    Board = plink.Board,
                    Thread = plink.Thread,
                    Post = plink.Post
                };
            }
            return null;
        }

        /// <summary>
        /// Получить имя файла медиа.
        /// </summary>
        /// <param name="link">Ссылка.</param>
        /// <returns>Имя файла.</returns>
        public string GetMediaFileName(BoardLinkBase link)
        {
            string uri = null;
            var bml = link as BoardMediaLink;
            if (bml != null)
            {
                uri = bml.RelativeUri;
            }
            var ml = link as MediaLink;
            if (ml != null)
            {
                uri = ml.RelativeUri;
            }
            var yl = link as YoutubeLink;
            if (yl != null)
            {
                return $"youtube-{yl.YoutubeId}.jpg";
            }
            var lp = uri?.Split('/').LastOrDefault(p => !string.IsNullOrWhiteSpace(p));
            return lp?.Trim();
        }

        /// <summary>
        /// Средство сравнения ссылок.
        /// </summary>
        private sealed class LinkComparer : IComparer<BoardLinkBase>
        {
            public static readonly LinkComparer Instance = new LinkComparer();

            private readonly Dictionary<Type, Func<BoardLinkBase, CompareValues>> _valueGetters;

            private LinkComparer()
            {
                _valueGetters = new Dictionary<Type, Func<BoardLinkBase, CompareValues>>()
                {
                    {typeof(BoardLink), CreateGetter<BoardLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = 0, Post = 0, Other = ""})},
                    {typeof(BoardPageLink), CreateGetter<BoardPageLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = l.Page, Thread = 0, Post = 0, Other = ""})},
                    {typeof(ThreadLink), CreateGetter<ThreadLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = l.Thread, Post = 0, Other = ""})},
                    {typeof(ThreadPartLink), CreateGetter<ThreadPartLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = l.Thread, Post = 0, Other = ""})},
                    {typeof(PostLink), CreateGetter<PostLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = l.Thread, Post = l.Post, Other = ""})},
                    {typeof(BoardMediaLink), CreateGetter<BoardMediaLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = 0, Post = 0, Other = l.RelativeUri ?? ""})},
                    {typeof(MediaLink), CreateGetter<MediaLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = "", Page = 0, Thread = 0, Post = 0, Other = l.RelativeUri ?? ""})},
                    {typeof(YoutubeLink), CreateGetter<YoutubeLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = "", Page = 0, Thread = 0, Post = 0, Other = l.YoutubeId ?? ""})},
                    {typeof(RootLink), CreateGetter<RootLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = "", Page = 0, Thread = 0, Post = 0, Other = ""})},
                    {typeof(ThreadTagLink), CreateGetter<ThreadTagLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = 0, Post = 0, Other = l.Tag ?? ""})},
                    {typeof(BoardCatalogLink), CreateGetter<BoardCatalogLink>(l => new CompareValues() { Engine = l.Engine ?? "", Board = l.Board ?? "", Page = 0, Thread = 0, Post = 0, Other = l.Sort.ToString()})},
                };
            }

            private static Func<BoardLinkBase, CompareValues> CreateGetter<T>(Func<T, CompareValues> func)
                where T : BoardLinkBase
            {
                return a => func((T) a);
            }

            private CompareValues GetValue(BoardLinkBase link)
            {
                if (link != null)
                {
                    var t = link.GetType();
                    if (_valueGetters.ContainsKey(t))
                    {
                        return _valueGetters[t](link);
                    }
                }
                return new CompareValues()
                {
                    Board = "",
                    Engine = "",
                    Other = "",
                    Post = 0,
                    Thread = 0,
                    Page = 0
                };
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <returns>
            /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
            /// </returns>
            /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
            public int Compare(BoardLinkBase x, BoardLinkBase y)
            {
                var x1 = GetValue(x);
                var y1 = GetValue(y);
                return x1.CompareTo(y1);
            }            

            private struct CompareValues : IComparable<CompareValues>
            {
                public string Engine;

                public string Board;

                public int Page;

                public int Thread;

                public int Post;

                public string Other;

                /// <summary>
                /// Compares the current object with another object of the same type.
                /// </summary>
                /// <returns>
                /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
                /// </returns>
                /// <param name="other">An object to compare with this object.</param>
                public int CompareTo(CompareValues other)
                {
                    var er = StringComparer.OrdinalIgnoreCase.Compare(Engine, other.Engine);
                    if (er != 0)
                    {
                        return er;
                    }
                    var br = StringComparer.OrdinalIgnoreCase.Compare(Board, other.Board);
                    if (br != 0)
                    {
                        return br;
                    }
                    var bpr = Comparer<int>.Default.Compare(Page, other.Page);
                    if (bpr != 0)
                    {
                        return bpr;
                    }
                    var tr = Comparer<int>.Default.Compare(Thread, other.Thread);
                    if (tr != 0)
                    {
                        return tr;
                    }
                    var pr = Comparer<int>.Default.Compare(Post, other.Post);
                    if (pr != 0)
                    {
                        return pr;
                    }
                    var or = StringComparer.Ordinal.Compare(Other, other.Other);
                    if (or != 0)
                    {
                        return or;
                    }
                    return 0;
                }
            }
        }
    }
}