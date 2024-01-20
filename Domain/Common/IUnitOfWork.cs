namespace Domain.Common;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
    ITransaction BeginTransaction();
    T ServiceAs<T>() where T : IDomainService;
}
