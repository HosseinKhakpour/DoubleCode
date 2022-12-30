using DoubleCode.Domain.Entities.Articles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleCode.Domin.Entities.Tags;

namespace DoubleCode.Infrastructure.FluentAPI.TagConfigs
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(20);

        }
    }
}
