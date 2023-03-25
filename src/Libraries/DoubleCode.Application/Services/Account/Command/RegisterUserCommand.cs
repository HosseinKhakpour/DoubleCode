using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Application.Common.Utilities.Security;
using DoubleCode.Application.Services.Account.ViewModel;
using DoubleCode.Domain.Base;
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
    #endregion

    #region Ctor
    public RegisterUserCommandHandler(ISecurityService securityService, IApplicationDbContext context)
    {
        _securityService = securityService;
        _context = context;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var hassPassword = _securityService.HashPassword(request.RegisterUser_VM.Password);
            var user = await _context.User.AddAsync();
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            var m = ex.Message;

            return false;
        }
    }
    #endregion
}
