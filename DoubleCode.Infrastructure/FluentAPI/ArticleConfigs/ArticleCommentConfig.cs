using DoubleCode.Domain.Entities.Articles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Infrastructure.FluentAPI.ArticleConfigs
{ 
    public class ArticleCommentConfig : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.Property(d => d.CommentText).IsRequired().HasMaxLength(500);
            builder.Property(d => d.CreateDate).HasColumnType("datetime2");

            #region Relations

            builder.HasOne(s => s.Article)
                .WithMany(p => p.ArticleComments)
                .HasForeignKey(s => s.ArticleId);
            builder.HasOne(s => s.User)
                .WithMany(p => p.ArticleComments)
                .HasForeignKey(s => s.UserId);
            #endregion
        }
    }
}
