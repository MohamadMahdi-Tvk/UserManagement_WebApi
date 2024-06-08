using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.DataAccess.Repositories;

public interface IUserRoleRepository
{
    Task CreateRole(UserRole userRole);

    Task<UserRole> GetUserRoleById(int id);

    Task<List<GetUserRolesResponse>> GetAllUserRoles();

    Task DeleteUserRole(int id);


}

public class UserRoleRepository : IUserRoleRepository
{
    private readonly DatabaseContext _context;
    public UserRoleRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateRole(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
    }

    public async Task<UserRole> GetUserRoleById(int id)
    {
        var userRole = await _context.UserRoles
            .Include(t => t.User)
            .Include(t => t.Role)
            .FirstOrDefaultAsync(t => t.Id == id);

        return userRole;

    }

    public async Task<List<GetUserRolesResponse>> GetAllUserRoles()
    {
        var userRoles = await _context.UserRoles
            .AsNoTracking()
            .Include(u => u.User)
            .Include(u => u.Role)
            .Select(p => new GetUserRolesResponse(p.Role.Id,p.User.FullName ,p.Role.Title ))
            .ToListAsync();

        return userRoles;
    }

    public async Task DeleteUserRole(int id)
    {
        var userRole = await _context.UserRoles.FirstOrDefaultAsync(t => t.Id == id);

        _context.UserRoles.Remove(userRole);
    }
}


