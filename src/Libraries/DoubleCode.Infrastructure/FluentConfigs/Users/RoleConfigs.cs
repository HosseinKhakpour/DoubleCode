using DoubleCode.Domain.Entity.Permissions;
using DoubleCode.Domain.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoubleCode.Infrastructure.FluentConfigs.Users;

public class RoleConfigs : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
    }
}
