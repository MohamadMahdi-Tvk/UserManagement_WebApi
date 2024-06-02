using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services.Roles.Commands;
using UserManagement.Application.Services.Roles.Queries;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles;
using UserManagement.DataAccess.ViewModels.Roles.Commands;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost, Route(nameof(Create))]
    public async Task<CreateRoleResponse> Create(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var addRole = await _mediator.Send(new CreateRoleCommand(request, cancellationToken));

        return addRole;
    }

    [HttpGet, Route(nameof(GetRoles))]
    public async Task<List<GetRolesResponse>> GetRoles(CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new GetRolesQuery(cancellationToken));
        return model;

    }

    [HttpPost, Route(nameof(GetRoleById))]
    public async Task<GetRoleByIdResponse> GetRoleById(GetRoleByIdRequest request, CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new GetRoleByIdQuery(request, cancellationToken));

        return model;
    }

    [HttpPost, Route(nameof(Update))]
    public async Task<UpdateRoleResponse> Update(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var roleUpdate = await _mediator.Send(new UpdateRoleCommand(request, cancellationToken));

        return roleUpdate;
    }

}
