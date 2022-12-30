using DoubleCode.Domain.Entities.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Infrastructure.FluentAPI.ArticleConfigs
{
    public class ArticleTagConfig : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            #region Relations

            builder.HasOne(s => s.Article)
                .WithMany(p => p.ArticleTags)
                .HasForeignKey(s => s.ArticleId);
            builder.HasOne(s => s.Tag)
                .WithMany(p => p.ArticleTags)
                .HasForeignKey(s => s.TagId);

            #endregion
        }
    }
}
