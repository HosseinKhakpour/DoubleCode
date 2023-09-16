using DoubleCode.Domain.Base;
using MediatR;

public class NonClass : IRequest<BaseResult_VM<bool>>
{
}
public class Handler : IRequestHandler<NonClass, BaseResult_VM<bool>>
{
    #region Property

    #endregion

    #region Ctor
    public Handler()
    {
        
    }
    #endregion

    #region Method
    public async Task<BaseResult_VM<bool>> Handle(NonClass request, CancellationToken cancellationToken)
    {
        return new BaseResult_VM<bool>
        {
            Result = true,
            Code =0,
            Message ="",

        };
    }

    #endregion
}


