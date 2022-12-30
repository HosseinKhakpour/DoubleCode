using DoubleCode.Domain.Base;
using DoubleCode.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Domain.Entities.Articles
{
    /// <summary>
    /// Represents a Article post
    /// </summary>
    public class Article : BaseEntity<int>, IDetaEntity
    {
        /// <summary>
        /// Gets or sets the Article title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Article Writer
        /// </summary>
        public string Writer { get; set; }

        /// <summary>
        /// Gets or sets the Article Heder
        /// </summary>
        public string Heder { get; set; }

        /// <summary>
        /// Gets or sets the Article body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the Article ImageName
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets the Article tags
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the  group Id
        /// </summary>
        public int GroupId { get; set; }

        #region Date

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations
        public ICollection<ArticleTag> ArticleTags { get; set; }

        public ICollection<ArticleComment> ArticleComments { get; set; }
        public ArticleGroup ArticleGroup  { get; set; }

        #endregion

    }

}

