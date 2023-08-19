using DoubleCode.Application.Common.Utilities.AutoMapper;
using DoubleCode.Domain.Entity.Permissions;

namespace DoubleCode.Application.Services.Permissions.ViewModel;
public class RolePermission_VM : IMapFrom<RolePermission>
{
    public int RoleId { get; set; }
    public string PermissionTitle { get; set; }
    public string PermissionName { get; set; }
    public long? ParentId { get; set; }

}
