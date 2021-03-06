﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Все узлы поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostNodes
    {
        /// <summary>
        /// Узы поста.
        /// </summary>
        [DataMember]
        public List<PostNodeBase> Nodes { get; set; }
    }
}