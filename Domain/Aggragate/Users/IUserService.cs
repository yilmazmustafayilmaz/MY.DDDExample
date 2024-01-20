namespace Domain.Aggragate.Users;

public interface IUserService : IDomainService
{
    void Insert(User user);
    User Get(int? id);
    User GetByEmail(string? email);
}
