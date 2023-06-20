
using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoubleCode.Application.Services.Account.Command;

public class ActiveteAccountQuery : IRequest<BaseResult_VM<bool>>
{
    public  string? EmailActivCode { get; set; }
}
public class ActiveteAccountQueryHandler : IRequestHandler<ActiveteAccountQuery, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext _context;
    #endregion

    #region Ctor
    public ActiveteAccountQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(ActiveteAccountQuery request, CancellationToken cancellationToken)
    {
       var user = await _context.User.FirstAsync( u=>u.EmailActiveCode == request.EmailActivCode);
        if(user == null)
        {
            
        }

        return new BaseResult_VM<bool>
        {
            Result = true,
            Code =0,
            Message ="",

        };
    }

    #endregion
}


