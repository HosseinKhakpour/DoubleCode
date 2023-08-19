﻿using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Domain.Base;
using MediatR;

namespace DoubleCode.Application.Services.Permissions.Command;
public class RemoveRolePermissionCommand : IRequest<BaseResult_VM<bool>>
{
    public int? RolePermissionId { get; set; }

}
public class RemoveRolePermissionCommandHandler : IRequestHandler<RemoveRolePermissionCommand, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext _context;
    #endregion

    #region Ctor
    public RemoveRolePermissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(RemoveRolePermissionCommand request, CancellationToken cancellationToken)
    {
        var rolePermission = await _context.RolePermission.FindAsync(request.RolePermissionId);
        if (rolePermission == null)
            return new BaseResult_VM<bool>
            {
                Result = true,
                Code = 0,
                Message = "دسترسی موردنظر یافت نشد",
            };

        _context.RolePermission.Remove(rolePermission);
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