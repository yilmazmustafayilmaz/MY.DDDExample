using Application.Common.CQ;
using Application.UseCase.Users.DTOs;
using Domain.Aggragate.Users;
using Domain.Common;

namespace Application.UseCase.Users.CQHandler;

public sealed partial class UserCQHandler : Handler<IUserService>,
IRequestHandler<Insert<UserDto>, bool>,
IRequestHandler<Update<UserDto>>,
IRequestHandler<Delete<UserDto, int>>
{
    private readonly IPasswordHasher _passwordHasher;
    public UserCQHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        : base(unitOfWork)
        => _passwordHasher = passwordHasher;

    public async Task<bool> Handle(Insert<UserDto> request, CancellationToken cancellationToken)
    {
        using (var transaction = UnitOfWork.BeginTransaction())
        {
            try
            {
                User user = new();
                user.Name = request.dto.Name;
                user.Surname = request.dto.Surname;
                user.Email = request.dto.Email;
                user.Role = request.dto.Role;
                (byte[] hash, byte[] salt) = _passwordHasher.HashPassword(request.dto.Password!);
                user.SetPassword(hash, salt);

                Service.Insert(user); //TODO: make async

                await UnitOfWork.CommitAsync(cancellationToken); //TODO: use await with Task.WhenAll 
                await transaction.CommitAsync();
                return await Success();
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public Task Handle(Update<UserDto> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(Delete<UserDto, int> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
