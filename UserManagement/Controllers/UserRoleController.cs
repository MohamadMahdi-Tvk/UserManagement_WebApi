using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services.UserRoles.Commands;
using UserManagement.Application.Services.UserRoles.Queries;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

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

    [HttpPost, Route(nameof(GetUserRoleById))]
    public async Task<GetUserRoleByIdResponse> GetUserRoleById(GetUserRoleByIdRequest request, CancellationToken cancellationToken)
    {
        var userRole = await _mediator.Send(new GetUserRoleByIdCommand(request, cancellationToken));

        return userRole;
    }



}
