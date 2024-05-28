using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly DatabaseContext _context;
    public UserRoleRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddUserRole(UserRole userRole)
    {
        await _context.AddAsync(userRole);
    }

    public async Task DeleteUserRole(UserRole userRole)
    {
        _context.Remove(userRole);
    }

    public async Task<List<UserRole>> GetAllUserRoles()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<UserRole> GetUserRoleById(int id)
    {
        return await _context.UserRoles.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}