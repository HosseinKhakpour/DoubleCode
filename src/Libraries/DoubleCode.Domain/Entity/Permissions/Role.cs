using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entity.User;
using Microsoft.AspNetCore.Identity;

namespace DoubleCode.Domain.Entity.Permissions;

public class Role : IdentityRole<int>
{
    #region Relations
    public ICollection<RolePermission> RolePermissions { get; set; }
    #endregion
}

