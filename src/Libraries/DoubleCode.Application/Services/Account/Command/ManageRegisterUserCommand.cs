using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Application.Services.Account.ViewModel;
using DoubleCode.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Application.Services.Account.Command;

public class ManageRegisterUserCommand : IRequest<BaseResult_VM<bool>>
{
    public RegisterUser_VM RegisterUser_VM { get; set; }
}
public class ManageRegisterUserCommandHandler : IRequestHandler<ManageRegisterUserCommand, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext _context;
    private readonly ISender sender;
    #endregion

    #region Ctor
    public ManageRegisterUserCommandHandler(IApplicationDbContext context, ISender sender)
    {
        _context = context;
        this.sender = sender;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(ManageRegisterUserCommand request, CancellationToken cancellationToken)
    {
      var register = await sender.Send(new RegisterUserCommand { RegisterUser_VM = request.RegisterUser_VM });

        return new BaseResult_VM<bool>
        {
            Result = true,
            Code = 0,
            Message = "",

        };
    }

    #endregion
}


