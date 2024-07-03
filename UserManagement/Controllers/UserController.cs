using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services.Users.Commands;
using UserManagement.Application.Services.Users.Queries;
using UserManagement.Controllers.Base;
using UserManagement.DataAccess.ViewModels.Users.Commands;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    public UserController(IMediator mediator, ILogger logger) : base(mediator, logger)
    {
    }


    [HttpPost]
    [Route(nameof(GetAll))]
    public async Task<List<UsersResponse>> GetAll(CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new GetUsersQuery(cancellationToken));
        return model;
    }


    [HttpPost]
    [Route(nameof(GetUsrById))]
    public async Task<GetUserByIdResponse> GetUsrById(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(request, cancellationToken));

        return user;
    }


    [HttpPost]
    [Route(nameof(Create))]
    public async Task<CreateUserResponse> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new CreateUserCommand(request, cancellationToken));
        return model;


        //var model = request with { FirstName = "ali" };
        //request.FirstName = "";
    }




    [HttpPost, Route(nameof(Delete))]
    public async Task<DeleteUserResponse> Delete(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var userDelete = await _mediator.Send(new DeleteUserCommand(request, cancellationToken));

        return userDelete;
    }



    [HttpPost, Route(nameof(Update))]
    public async Task<UpdateUserResponse> Update(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var userUpdated = await _mediator.Send(new UpdateUserCommand(request, cancellationToken));

        return userUpdated;
    }
}
