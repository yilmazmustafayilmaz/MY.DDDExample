namespace Domain.Common;

public interface ITransaction : IDisposable
{
    Task RollbackAsync();
    Task CommitAsync();
}
