
using DoubleCode.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoubleCode.Domain.Entity.Permissions;

public class RolePermission : BaseEntity
{
    public int RoleId { get; set; }
    public string PermissionTitle { get; set; }
    public string PermissionName { get; set; }
    public long
        ? ParentId { get; set; }

    #region Relations

    [ForeignKey("ParentId")]
    public List<RolePermission> Permissions { get; set; }
    public Role Roles { get; set; }

    #endregion

}

