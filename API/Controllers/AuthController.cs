using Application.Common.CQ;
using Application.UseCase.Users.DTOs;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(UserDto userDto)
        => Ok(await _mediator.Send(new Login<UserDto>(userDto)));
}
