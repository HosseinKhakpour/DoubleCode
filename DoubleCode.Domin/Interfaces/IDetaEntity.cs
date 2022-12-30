using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Domain.Interfaces
{
    public interface IDetaEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? LastModifyDate { get; set; }

    }
}
