using DoubleCode.Application.Common.Utilities.AutoMapper;
using DoubleCode.Domain.Entity.Permissions;

namespace DoubleCode.Application.Services.Permissions.ViewModel;
public class Role_VM : IMapFrom<Role>
{
    public string RoleTitle { get; set; }
}
