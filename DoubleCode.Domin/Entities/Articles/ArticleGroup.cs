using DoubleCode.Domain.Base;
using DoubleCode.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoubleCode.Domain.Entities.Articles
{
    public class ArticleGroup:BaseEntity<int>, IDetaEntity
    {
        /// <summary>
        /// Gets or sets the Article  Group Title
        /// </summary>
        /// 
        public string Title { get; set; }

        #region Date
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Article> Articles { get; set; }

        #endregion

    }
}
