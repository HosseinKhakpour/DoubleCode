using DoubleCode.Application.Common.Utilities.AutoMapper;
using DoubleCode.Domain.Entity.User;

namespace DoubleCode.Application.Services.Permissions.ViewModel;
public class UserRole_VM : IMapFrom<UserRole>
{
    public int UR { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public bool IsDeleted { get; set; }
}
