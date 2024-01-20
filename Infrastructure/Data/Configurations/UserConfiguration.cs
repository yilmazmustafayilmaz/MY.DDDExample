using Domain.Aggragate.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(t => t.Name)
           .HasMaxLength(100)
           .IsRequired();

        builder.OwnsOne(typeof(Password), "Password");
        builder.Navigation("Password").AutoInclude(true);
    }
}
