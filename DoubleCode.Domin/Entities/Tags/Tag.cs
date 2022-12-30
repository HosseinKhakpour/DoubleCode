using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Domin.Entities.Tags
{
    /// <summary>
    /// Represents a tag
    /// </summary>
    public class Tag : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        #region Relations
        public ICollection<ArticleTag> ArticleTags { get; set; }
        #endregion
    }
}