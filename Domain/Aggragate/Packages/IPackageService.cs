namespace Domain.Aggragate.Packages;

public interface IPackageService : IDomainService
{
    void Insert(Package package);
    Package Get(int? id);
}
