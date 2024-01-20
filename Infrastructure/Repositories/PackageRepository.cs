using Domain.Aggragate.Packages;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class PackageRepository : IPackageService
{
    private readonly ApplicationDbContext _context;

    public PackageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    //public PackageRepository(ApplicationDbContext context) : base(context) { }

    public Package Get(int? id) => _context.Packages.Find(id)!;
    public void Insert(Package package) { _context.Packages.Add(package); }
}
