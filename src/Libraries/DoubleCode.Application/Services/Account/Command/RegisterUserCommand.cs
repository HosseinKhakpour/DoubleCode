using AutoMapper;
using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Application.Common.Utilities.Security;
using DoubleCode.Application.Services.Account.ViewModel;
using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

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
    private readonly UserManager<User> userManager;
    #endregion

    #region Ctor
    public RegisterUserCommandHandler(ISecurityService securityService, IApplicationDbContext context, IMapper mapper, UserManager<User> userManager)
    {
        _securityService = securityService;
        _context = context;
        _mapper = mapper;
        this.userManager = userManager;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            User user = _mapper.Map<User>(request.RegisterUser_VM);
            var registerUser = await userManager.CreateAsync(user, request.RegisterUser_VM.Password);

            if (registerUser.Succeeded)
            {
                return new BaseResult_VM<bool>
                {
                    Result = true,
                    Code = 0,
                    Message = "ثبت نام با موفقیت انجام شد"
                };
            }

            if (registerUser.Errors.Count() != 0)
            {
                List<string> erroreMassage = new();
                foreach (var error in registerUser.Errors)
                {
                    erroreMassage.Add(error.Description);
                }
                var bb = registerUser.Errors.ToList();

                return new BaseResult_VM<bool>
                {
                    Result = false,
                    Code = -1,
                    Message = erroreMassage.First()

                };
            }
        }
        catch (Exception ex)
        {
            var m = ex.Message;
        }

        return new BaseResult_VM<bool>
        {
            Result = true,
            Code = 0,
            Message = "ثبت نام با موفقیت انجام شد"

        };
    }
    #endregion
}
