using Application.Common.CQ;
using Application.UseCase.Users.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<IActionResult> Add(UserDto userDto)
        => Ok(await _mediator.Send(new Insert<UserDto>(userDto)));

    [Authorize(Policy = "Admin")]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetById(UserDto userDto)
        => Ok(await _mediator.Send(new GetById<UserDto, int>(userDto.Id)));
}
