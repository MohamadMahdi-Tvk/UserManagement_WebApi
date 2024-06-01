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
    [Route(nameof(Create))]
    public async Task<CreateUserResponse> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new CreateUserCommand(request, cancellationToken));
        return model;


        //var model = request with { FirstName = "ali" };
        //request.FirstName = "";
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<List<UsersResponse>> GetAll(CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new GetUsersQuery(cancellationToken));
        return model;
    }


    //[HttpPost]
    //[Route(nameof(Delete))]
    //public async Task<IActionResult> Delete(int userId, CancellationToken cancellationToken)
    //{
    //    await _unitOfWork.UserRepository.DeleteUser(userId);

    //    await _unitOfWork.CommitAsync(cancellationToken);
    //    return Ok("Success!!");
    //}

    //[HttpGet]
    //[Route(nameof(GetUserById))]
    //public async Task<IActionResult> GetUserById(int userId)
    //{
    //    return Ok(await _unitOfWork.UserRepository.GetUserById(userId));
    //}

    //[HttpPost]
    //[Route(nameof(Update))]
    //public async Task<IActionResult> Update(UpdateUserRequest response, CancellationToken cancellationToken)
    //{
    //    await _unitOfWork.UserRepository.UpdateUser(response);

    //    await _unitOfWork.CommitAsync(cancellationToken);

    //    return Ok("Success!");
    //}
}
