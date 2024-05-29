using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpPost, Route(nameof(Create))]
    public async Task<IActionResult> Create(CreateUserRoleRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRoleRepository.AddUserRole(new UserRole
        {
            UserId = request.userId,
            RoleId = request.roleId
        });

        await _unitOfWork.CommitAsync(cancellationToken);

        return Ok("Success!");
    }


    [HttpGet, Route(nameof(GetUserRoles))]
    public async Task<IActionResult> GetUserRoles()
    {
        return Ok(await _unitOfWork.UserRoleRepository.GetAllUserRoles());
    }


    [HttpGet, Route(nameof(GetUserRoleById))]
    public async Task<IActionResult> GetUserRoleById(int id)
    {
        return Ok(await _unitOfWork.UserRoleRepository.GetUserRoleById(id));
    }

    [HttpPost, Route(nameof(Delete))]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRoleRepository.DeleteUserRole(id);
        await _unitOfWork.CommitAsync(cancellationToken);

        return Ok("Success!");
    }

    [HttpPost, Route(nameof(Update))]
    public async Task<IActionResult> Update(UpdateUserRoleResponse response, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRoleRepository.UpdateUserRole(response);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Ok("Success!");
    }
}
