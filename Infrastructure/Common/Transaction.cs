using Domain.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Common;

public sealed class Transaction : ITransaction, IDisposable
{
    private readonly IDbContextTransaction scope;
    internal Transaction([NotNull] ApplicationDbContext database)
    {
        scope = database.Database.BeginTransaction();
    }

    public Task CommitAsync() => scope.CommitAsync();
    public Task RollbackAsync() => scope.RollbackAsync();
    public void Dispose() => scope.Dispose();
}
