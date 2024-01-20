using Application.Common.Intefaces;
using Infrastructure.Data.Interceptors;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infrastructure.Data;

public sealed partial class ApplicationDbContext : DbContext
{

    private static readonly IConfigurationRoot configuration =
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = configuration.GetConnectionString("DatabaseConnection");
        optionsBuilder.UseSqlServer(connectionString).AddInterceptors(new AuditableEntityInterceptor(), 
                                                                      new DispatchDomainEventsInterceptor())
                                                                               .EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}