using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Application.Services.Account.Query;

public class CheckDuplicatedEmailQuery : IRequest<BaseResult_VM<bool>>
{
    public string Email { get; set; }
}
public class CheckDuplicatedEmailQueryHandler : IRequestHandler<CheckDuplicatedEmailQuery, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext _context;
    #endregion

    #region Ctor
    public CheckDuplicatedEmailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(CheckDuplicatedEmailQuery request, CancellationToken cancellationToken)
    {
        bool isDuplicated = await _context.User.AnyAsync(u => u.Email ==request.Email);
        if (isDuplicated) 
        {
            return new BaseResult_VM<bool>
            {
                Result = true,
                Code =0,
                Message ="",
            };
        }

        return new BaseResult_VM<bool>
        {
            Result = false,
            Code =-1,
            Message ="کاربر با این ایمیل وجود دارد ",
        };
    }

    #endregion
}


