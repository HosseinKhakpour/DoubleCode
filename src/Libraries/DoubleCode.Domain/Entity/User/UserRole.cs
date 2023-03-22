

using DoubleCode.Domain.Entity.Permissions;
using System.ComponentModel.DataAnnotations;

namespace DoubleCode.Domain.Entity.User;

public class UserRole
{
    [Key]
    public int UR { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public bool IsDeleted { get; set; }

    #region Relations

    public User User { get; set; }
    public Role Role { get; set; }

    #endregion

}

