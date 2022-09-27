using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArchitecture.Features.Users.CreateUser;

namespace VerticalSliceArchitecture.Features.Users;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        CreateUserCommand createUserCommand)
    {
        var response = await _mediator.Send(createUserCommand);

        return Ok(response);
    }
}
