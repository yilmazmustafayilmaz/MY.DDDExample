using Domain.Aggragate.Packages;
using Domain.Aggragate.Users;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infrastructure.Data;

public sealed partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Package> Packages { get; set; }
    public DbSet<User> Users { get; set; }
}
