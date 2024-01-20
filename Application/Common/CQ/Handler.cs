using Domain.Common;

namespace Application.Common.CQ;

public class Handler<TDBService> where TDBService : IDomainService
{
    public Handler(IUnitOfWork unitOfWork)
    {
        Service = unitOfWork.ServiceAs<TDBService>();
        UnitOfWork = unitOfWork;
    }

    public TDBService Service { get; set; }
    public IUnitOfWork UnitOfWork { get; set; }
    public static Task<bool> Success() => Task.FromResult(true);
    public static Task<T> Success<T>(T dto) => Task.FromResult(dto);
}
