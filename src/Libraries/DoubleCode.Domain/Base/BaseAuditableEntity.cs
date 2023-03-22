namespace DoubleCode.Domain.Base;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
