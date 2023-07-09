using DoubleCode.Domain.Base;

namespace DoubleCode.Domain.Entity.User;

public class User : BaseAuditableEntity
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
