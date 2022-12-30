using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleCode.Domain.Entities.Articles;

namespace DoubleCode.Infrastructure.FluentAPI.ArticleConfigs
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {

            builder.Property(d => d.Title).IsRequired().HasMaxLength(70);
            builder.Property(d => d.Writer).IsRequired().HasMaxLength(70);
            builder.Property(d => d.CreateDate).HasColumnType("datetime2");
            builder.Property(d => d.GroupId).IsRequired();


            #region Relations

            builder.HasOne(s => s.ArticleGroup)
                .WithMany(p => p.Articles)
                .HasForeignKey(s => s.GroupId);

            #endregion

        }
    }
}
