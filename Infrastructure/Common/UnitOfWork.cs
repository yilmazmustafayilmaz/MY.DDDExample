using Domain.Common;
using Infrastructure.Data;
using System.Collections.Concurrent;

namespace Infrastructure.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context = new();
    private static readonly object _sync = new();
    private static readonly IDictionary<Type, Type> activators =
        new ConcurrentDictionary<Type, Type>();

    public ITransaction BeginTransaction() => new Transaction(context);
    public Task<int> CommitAsync(CancellationToken cancellationToken = default) => context.SaveChangesAsync(cancellationToken);

    public T ServiceAs<T>() where T : IDomainService
    {
        Type type = typeof(T);
        if (!activators.TryGetValue(type, out Type service))
        {
            lock (_sync)
            {
                if (!activators.TryGetValue(type, out service))
                {
                    service = typeof(UnitOfWork).Assembly.GetTypes().Single(typ => typ.GetInterfaces().Any(e => e.Equals(type)));
                    activators.TryAdd(type, service);
                }
            }
        }
        return (T)Activator.CreateInstance(service, new object[] { context });
    }

    private bool isDispossed;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool dispossing)
    {
        if (isDispossed)
            return;
        if (dispossing)
            context.Dispose();
        isDispossed = true;
    }
}
