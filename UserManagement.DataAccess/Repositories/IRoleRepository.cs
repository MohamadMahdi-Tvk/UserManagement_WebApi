using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Roles.Commands;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();

        Task<Role> GetRoleById(int Id);

        Task UpdateRole(Role NewRole);

        Task DeleteRole(int Id);

        Task AddRole(Role Role);

    }

    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext _context;
        public RoleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddRole(Role Role)
        {
            await _context.Roles.AddAsync(Role);
        }

        public async Task DeleteRole(int Id)
        {
            _context.Roles.Remove(new Role { Id = Id });
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int Id)
        {
            return await _context.Roles.FindAsync(Id);

        }

        public async Task UpdateRole(Role NewRole)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == NewRole.Id);

            role.Title = NewRole.Title;

        }
    }
}
