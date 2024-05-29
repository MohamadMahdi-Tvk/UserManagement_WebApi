using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles;

namespace UserManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.RoleRepository.AddRole(new Role
        {
            Title = request.title
        });

        await _unitOfWork.CommitAsync(cancellationToken);
        return Ok("Success!");
    }

    [HttpGet]
    [Route(nameof(GetRoleById))]
    public async Task<IActionResult> GetRoleById(int id)
    {
        return Ok(await _unitOfWork.RoleRepository.GetRoleById(id));
    }

    [HttpGet]
    [Route(nameof(GetRoles))]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(await _unitOfWork.RoleRepository.GetAllRoles());
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<IActionResult> Update(UpdateRoleResponse response, CancellationToken cancellationToken)
    {
        await _unitOfWork.RoleRepository.UpdateRole(response);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Ok("Success!");
    }

    [HttpPost, Route(nameof(Delete))]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _unitOfWork.RoleRepository.DeleteRole(id);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Ok("Delete Operation Successfull!");
    }
}
