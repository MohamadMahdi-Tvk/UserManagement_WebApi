using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services.UserRoles.Commands;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost, Route(nameof(Create))]
    public async Task<CreateUserRoleResponse> Create(CreateUserRoleRequest request, CancellationToken cancellationToken)
    {
        var userRole = await _mediator.Send(new CreateUserRolesCommand(request, cancellationToken));

        return userRole;
    }

}
