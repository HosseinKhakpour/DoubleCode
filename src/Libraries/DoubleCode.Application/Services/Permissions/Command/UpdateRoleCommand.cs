﻿using AutoMapper;
using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Domain.Base;
using DoubleCode.Domain.Entity.Permissions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoubleCode.Application.Services.Permissions.Command;

public class UpdateRoleCommand : IRequest<BaseResult_VM<bool>>
{
    public long? RoleId { get; set; }
    public string? RoleTitle { get; set; }
}
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, BaseResult_VM<bool>>
{
    #region Property
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;
    #endregion

    #region Ctor
    public UpdateRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {

        Role? role = await context.Role.FirstOrDefaultAsync(r => r.Id == request.RoleId);
        if (role == null)
            return new BaseResult_VM<bool> { Result = false, Code = -1, };

        //TODO :Remove Permissions this Role

        role.RoleTitle = request.RoleTitle ?? "بدون عنوان ";
        context.Role.Update(role);
        await context.SaveChangesAsync(cancellationToken);

        return new BaseResult_VM<bool>
        {
            Result = true,
            Code = 0,
            Message = "با موفقیت بروزرسانی شد",
        };
    }

    #endregion
}


