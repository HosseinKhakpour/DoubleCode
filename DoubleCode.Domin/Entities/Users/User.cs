using DoubleCode.Domain.Entities.Articles;
using DoubleCode.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoubleCode.Domain.Entities.Users
{
    public class User : IdentityUser, IDetaEntity
    {
        public bool IsDeleted { get; set; }

        #region Date
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<ArticleComment> ArticleComments { get; set; }
        #endregion

    }
}
