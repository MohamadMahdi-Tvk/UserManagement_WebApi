using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRepository.AddUser(new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            UserName = request.UserName,
        });

        await _unitOfWork.CommitAsync(cancellationToken);
        //var model = request with { FirstName = "ali" };
        //request.FirstName = "";

        return Ok("Success!");
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.UserRepository.GetAllUsers());
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(int userId, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRepository.DeleteUser(userId);

        await _unitOfWork.CommitAsync(cancellationToken);
        return Ok("Success!!");
    }

    [HttpGet]
    [Route(nameof(GetUserById))]
    public async Task<IActionResult> GetUserById(int userId)
    {
        return Ok(await _unitOfWork.UserRepository.GetUserById(userId));
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<IActionResult> Update(UpdateUserResponse response, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRepository.UpdateUser(response);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Ok("Success!");
    }
}
