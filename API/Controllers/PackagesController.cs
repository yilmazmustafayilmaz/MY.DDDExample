using Application.Common.CQ;
using Application.UseCase.Packages.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PackagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PackagesController(IMediator mediator)
        => _mediator = mediator;

    //[Authorize(Policy = "Admin")]
    [HttpPost("[action]")]
    public async Task<IActionResult> Add(PackageDto packageDto)
        => Ok(await _mediator.Send(new Insert<PackageDto>(packageDto)));

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetById(PackageDto packageDto)
        => Ok(await _mediator.Send(new GetById<PackageDto, int>(packageDto.Id)));
}
