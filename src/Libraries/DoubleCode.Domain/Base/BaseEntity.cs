using System.ComponentModel.DataAnnotations;

namespace DoubleCode.Domain.Base;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public bool IsDeleted { get; set; }

}
