using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entity.Permissions;
using MediatR;

namespace DoubleCode.Application.Services.Permissions.Command;

public class AddRoleCommand : IRequest<BaseResult_VM<bool>>
{
    public string? RoleTitle { get; set; }
}
public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext context;
    #endregion

    #region Ctor
    public AddRoleCommandHandler(IApplicationDbContext context)
    {
        context = context;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Name = request.RoleTitle ?? "بدون عنوان",
        };
        await context.Role.AddAsync(role);
        await context.SaveChangesAsync(cancellationToken);

        return new BaseResult_VM<bool>
        {
            Result = true,
            Code = 0,
            Message = "با موفقیت افزوده شد",
        };
    }

    #endregion
}


