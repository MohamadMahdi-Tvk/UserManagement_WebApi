using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext _context;
        public RoleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public async Task DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(p => p.Id == roleId);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
