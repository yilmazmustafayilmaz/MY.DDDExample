using Application.Common.CQ;
using Application.Common.Security;
using Application.UseCase.Users.DTOs;
using Domain.Aggragate.Users;
using Domain.Common;

namespace Application.UseCase.Auth.CQHandler;

public sealed partial class AuthCQHandler : Handler<IUserService>,
    IRequestHandler<Login<UserDto>, string>,
    IRequestHandler<Register<UserDto>, string>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    public AuthCQHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtService jwtService) : base(unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(Login<UserDto> request, CancellationToken cancellationToken)
    {
        using (var transaction = UnitOfWork.BeginTransaction())
        {
            try
            {
                User user = Service.GetByEmail(request.dto.Email);
                if (user is null) throw new Exception("Invalid_Email");
                if (!_passwordHasher.VerifyHashedPassword(request.dto.Password, user.Password.Salt, user.Password.Hash))
                    throw new Exception("Invalid_Password");

                var tokens = ClaimBuilder.Create()
                    .SetEmail(user.Email)
                    .SetRole(user.Role)
                    .SetId(user.Id.ToString())
                    .Build();
                var token = _jwtService.BuildToken(tokens);
                return await Success(token);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public Task<string> Handle(Register<UserDto> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
