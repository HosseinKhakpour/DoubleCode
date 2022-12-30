using DoubleCode.Domain.Base;
using DoubleCode.Domin.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Domain.Entities.Articles
{
    /// <summary>
    /// Represents a Article tag
    /// </summary>
    public class ArticleTag : BaseEntity<int>
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }


        #region Relations
        public Article Article { get; set; }
        public Tag Tag { get; set; }

        #endregion
    }
}
