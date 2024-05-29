using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Roles;

namespace UserManagement.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();

        Task<Role> GetRoleById(int roleId);

        Task UpdateRole(UpdateRoleResponse response);

        Task DeleteRole(int id);

        Task AddRole(Role role);

    }

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

        public async Task DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);

            _context.Remove(role);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task UpdateRole(UpdateRoleResponse response)
        {
            var role = _context.Roles.Find(response.roleId);

            role.Title = response.title;

        }

    


    }
}
