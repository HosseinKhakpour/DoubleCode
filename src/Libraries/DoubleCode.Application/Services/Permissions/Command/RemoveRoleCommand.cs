﻿using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Domain.Base;
using MediatR;

namespace DoubleCode.Application.Services.Permissions.Command;
public class RemoveRoleCommand : IRequest<BaseResult_VM<bool>>
{
    public int? RoleId { get; set; }

}
public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext _context;
    #endregion

    #region Ctor
    public RemoveRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Role.FindAsync(request.RoleId);
        if (role == null)
            return new BaseResult_VM<bool>
            {
                Result = true,
                Code = 0,
                Message = "نقش موردنظر یافت نشد",
            };

        _context.Role.Remove(role);
        await _context.SaveChangesAsync(cancellationToken);

        return new BaseResult_VM<bool>
        {
            Result = true,
            Code = 0,
            Message = "با موفقیت حذف شد",

        };
    }

    #endregion
}