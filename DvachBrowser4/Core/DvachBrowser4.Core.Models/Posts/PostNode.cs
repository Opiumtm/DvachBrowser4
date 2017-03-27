using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DvachBrowser4.Core.Models.Posts
{
    /// <summary>
    /// Узел поста.
    /// </summary>
    [DataContract(Namespace = CoreConstants.DvachBrowserNamespace)]
    public class PostNode : PostNodeBase
    {
        /// <summary>
        /// Дочерние узлы.
        /// </summary>
        [DataMember]
        public List<PostNodeBase> Children { get; set; }

        /// <summary>
        /// Аттрибут.
        /// </summary>
        [DataMember]
        public PostNodeAttributeBase Attribute { get; set; }
    }
}