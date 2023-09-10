using DoubleCode.Domain.Base;
using Microsoft.AspNetCore.Identity;
namespace DoubleCode.Domain.Entity.User;

public class User : IdentityUser<int>
{
    public bool IsBlocked { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

}
