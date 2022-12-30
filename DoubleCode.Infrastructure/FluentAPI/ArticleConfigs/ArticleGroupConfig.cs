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
    public class ArticleGroupConfig : IEntityTypeConfiguration<ArticleGroup>
    {
        public void Configure(EntityTypeBuilder<ArticleGroup> builder)
        {

            builder.Property(d => d.Title).IsRequired().HasMaxLength(50);
            builder.Property(d => d.CreateDate).HasColumnType("datetime2");


        }
    }
}
