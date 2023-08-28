using AutoMapper;
using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Application.Common.Utilities.Security;
using DoubleCode.Application.Services.Account.ViewModel;
using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entity.User;
using MediatR;

namespace DoubleCode.Application.Services.Account.Command;

public class RegisterUserCommand : IRequest<BaseResult_VM<bool>>
{
    public RegisterUser_VM RegisterUser_VM { get; set; }
}
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResult_VM<bool>>
{
    #region Property
    private readonly ISecurityService _securityService;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public RegisterUserCommandHandler(ISecurityService securityService, IApplicationDbContext context, IMapper mapper)
    {
        _securityService = securityService;
        _context = context;
        _mapper=mapper;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            User user = _mapper.Map<User>(request.RegisterUser_VM);
          //  user.Password =_securityService.HashPassword(request.RegisterUser_VM.Password);

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResult_VM<bool>
            {
                Result =true,
                Code=0,
                Message ="ثبت نام با موفقیت انجام شد"
                 
            };
        }
        catch (Exception ex)
        {
            var m = ex.Message;

            return new BaseResult_VM<bool>
            {
                Result =true,
                Code=0,
                Message ="ثبت نام با موفقیت انجام شد"

            };
        }
    }
    #endregion
}
