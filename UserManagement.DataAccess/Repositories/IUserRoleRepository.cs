using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.UserRoles;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;
using UserManagement.DataAccess.ViewModels.Users;

namespace UserManagement.DataAccess.Repositories;

public interface IUserRoleRepository
{
    Task<CreateUserRoleResponse> CreateRole(UserRole userRole);

    Task<GetUserRoleByIdResponse> GetUserRoleById(int id);

    //Task<List<UserRoleResponse>> GetAllUserRoles();

    //Task UpdateUserRole(UpdateUserRoleResponse response);

    //Task DeleteUserRole(int id);


}

public class UserRoleRepository : IUserRoleRepository
{
    private readonly DatabaseContext _context;
    public UserRoleRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CreateUserRoleResponse> CreateRole(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        return new CreateUserRoleResponse(IsSuccess: true);
    }

    public async Task<GetUserRoleByIdResponse> GetUserRoleById(int id)
    {
        var userRole = await _context.UserRoles
            .AsNoTracking()
            .Include(t => t.User)
            .Include(t => t.Role)
            .FirstOrDefaultAsync(t => t.Id == id);


        return new GetUserRoleByIdResponse($"{userRole.User.FirstName} - {userRole.User.LastName}", userRole.Role.Title);

    }

    //public async Task DeleteUserRole(int id)
    //{
    //    var userRole = await _context.UserRoles.FindAsync(id);

    //    _context.UserRoles.Remove(userRole);
    //}

    //public async Task<List<UserRoleResponse>> GetAllUserRoles()
    //{
    //    return await _context.UserRoles
    //        .AsNoTracking()
    //        .Include(u => u.User)
    //        .Include(u => u.Role)
    //        .Select(x => new UserRoleResponse(x.Id, x.Role.Title, x.User.UserName))
    //        .ToListAsync();
    //}




    //public async Task UpdateUserRole(UpdateUserRoleResponse response)
    //{
    //    var userRole = await _context.UserRoles.FindAsync(response.id);

    //    userRole.RoleId = response.roleId;
    //    userRole.UserId = response.userId;

    //}
}


