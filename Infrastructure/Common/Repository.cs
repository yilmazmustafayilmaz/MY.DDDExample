using Infrastructure.Data;

namespace Infrastructure.Common;

public class Repository<T> where T : class
{
    protected readonly ApplicationDbContext context;
    protected readonly DbSet<T> entity;

    protected Repository(ApplicationDbContext context)
    {
        this.context = context;
        entity = context.Set<T>();
    }
}
