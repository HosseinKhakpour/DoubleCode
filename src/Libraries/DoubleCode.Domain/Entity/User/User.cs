using DoubleCode.Domain.Base;
using Microsoft.AspNetCore.Identity;
namespace DoubleCode.Domain.Entity.User;

public class User  : IdentityUser
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsEmailAtive { get; set; }
    public string? EmailActiveCode { get; set; }

    #region Relations
    public List<UserRole> UserRoles { get; set; }
    #endregion

}
