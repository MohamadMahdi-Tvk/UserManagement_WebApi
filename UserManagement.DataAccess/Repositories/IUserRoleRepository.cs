using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.DataAccess.Repositories;

public interface IUserRoleRepository
{
    Task<CreateUserRoleResponse> CreateRole(UserRole userRole);

    Task<UserRole> GetUserRoleById(int id);

    Task<List<GetUserRolesResponse>> GetAllUserRoles();


    //Task<UpdateUserRoleResponse> UpdateUserRole(UpdateUserRoleRequest response);

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
        return await _context.UserRoles
            .AsNoTracking()
            .Include(u => u.User)
            .Include(u => u.Role)
            .Select(u => new GetUserRolesResponse(u.Id, $"{u.User.UserName} - {u.User.LastName}", u.Role.Title))
            .ToListAsync();

    }


    //public async Task DeleteUserRole(int id)
    //{
    //    var userRole = await _context.UserRoles.FindAsync(id);

    //    _context.UserRoles.Remove(userRole);
    //}

}


