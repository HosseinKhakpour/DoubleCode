

using DoubleCode.Domain.Entity.Permissions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoubleCode.Domain.Entity.User;

public class UserRole :IdentityUserRole<int>
{
    public User User { get; set; }
    public Role Role { get; set; }
}

