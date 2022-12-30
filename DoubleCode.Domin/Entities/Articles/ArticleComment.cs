using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entities.Users;
using DoubleCode.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Domain.Entities.Articles
{
    /// <summary>
    /// Represents a Article comment
    /// </summary>
    public partial class ArticleComment : BaseEntity<int>,IDetaEntity
    {
        /// <summary>
        /// Gets or sets the User identifier
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the Article post identifier
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        public string CommentText { get; set; }

        #region Date
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public Article Article { get; set; }
        public User User { get; set; }
        #endregion
    }
}