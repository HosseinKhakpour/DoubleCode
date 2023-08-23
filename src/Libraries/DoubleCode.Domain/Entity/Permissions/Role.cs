using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entity.User;
using Microsoft.AspNetCore.Identity;

namespace DoubleCode.Domain.Entity.Permissions;

public class Role : IdentityRole
{
    public string RoleTitle { get; set; }

    #region Relations
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
    #endregion
}

