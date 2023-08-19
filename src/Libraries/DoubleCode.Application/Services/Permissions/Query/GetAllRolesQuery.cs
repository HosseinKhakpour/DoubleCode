using AutoMapper;
using DoubleCode.Application.Common.Interfaces;
using DoubleCode.Application.Services.Permissions.ViewModel;
using DoubleCode.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoubleCode.Application.Services.Permissions.Query;

public class GetAllRolesQuery : IRequest<BaseResult_VM<List<Role_VM>>>
{
}
public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, BaseResult_VM<List<Role_VM>>>
{
    #region Property
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;
    #endregion

    #region Ctor
    public GetAllRolesQueryHandler(IApplicationDbContext context , IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<List<Role_VM>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {

       var roles = await context.Role.ToListAsync();
        return new BaseResult_VM<List<Role_VM>>
        {
            Result = mapper.Map<List<Role_VM>>(roles),
            Code = 0,
            Message = "",

        };
    }

    #endregion
}


