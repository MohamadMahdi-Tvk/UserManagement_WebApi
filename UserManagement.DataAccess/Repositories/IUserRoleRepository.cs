using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.UserRoles;
using UserManagement.DataAccess.ViewModels.Users;

namespace UserManagement.DataAccess.Repositories;

public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAllUserRoles();
    Task<UserRole> GetUserRoleById(int id);
    Task AddUserRole(UserRole userRole);
    Task UpdateUserRole(UpdateUserRoleResponse response);
    Task DeleteUserRole(int id);


}

public class UserRoleRepository : IUserRoleRepository
{
    private readonly DatabaseContext _context;
    public UserRoleRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddUserRole(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
    }

    public async Task DeleteUserRole(int id)
    {
        var userRole = await _context.UserRoles.FindAsync(id);

        _context.UserRoles.Remove(userRole);
    }

    public async Task<List<UserRole>> GetAllUserRoles()
    {
        return await _context.UserRoles
            //.Include(u => u.User)
            //.Include(u => u.Role) --- Not Include !!!
            .ToListAsync();
    }

    public async Task<UserRole> GetUserRoleById(int id)
    {
        return await _context.UserRoles.FindAsync(id);
    }

 
    public async Task UpdateUserRole(UpdateUserRoleResponse response)
    {
        var userRole = await _context.UserRoles.FindAsync(response.id);

        userRole.RoleId = response.roleId;
        userRole.UserId = response.userId;

    }
}


