using Application.Common.CQ;
using Application.UseCase.Users.DTOs;
using Domain.Aggragate.Users;

namespace Application.UseCase.Users.CQHandler;

public sealed partial class UserCQHandler :
    IRequestHandler<GetById<UserDto, int>, UserDto>
{
    public Task<UserDto> Handle(GetById<UserDto, int> request, CancellationToken cancellationToken)
    {
        User user = Service.Get(request.Id);
        UserDto userDto = new(
            Id: user.Id,
            Name: user.Name,
            Surname: user.Surname,
            Email: user.Email,
            Password: null,
            Role: user.Role);

        return Success(userDto);
    }
}
