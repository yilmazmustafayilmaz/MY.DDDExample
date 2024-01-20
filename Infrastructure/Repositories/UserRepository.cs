using Domain.Aggragate.Users;
using Infrastructure.Common;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class UserRepository : Repository<User>, IUserService
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public User Get(int? id) => entity.Find(id)!;
    public User GetByEmail(string? email) => entity.FirstOrDefault(x => x.Email == email)!;
    public void Insert(User user) { entity.Add(user); }
}

