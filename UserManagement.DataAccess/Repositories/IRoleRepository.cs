using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Roles.Commands;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task<List<GetRolesResponse>> GetAllRoles();

        Task<Role> GetRoleById(int roleId);

        Task UpdateRole(UpdateRoleResponse response);

        Task DeleteRole(int id);

        Task<CreateRoleResponse> AddRole(Role Role);

    }

    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext _context;
        public RoleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CreateRoleResponse> AddRole(Role Role)
        {
            await _context.Roles.AddAsync(Role);
            return new CreateRoleResponse(IsSuccess: true);
        }

        public async Task DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);

            _context.Remove(role);
        }

        public async Task<List<GetRolesResponse>> GetAllRoles()
        {
            return await _context.Roles.Select(t => new GetRolesResponse(t.Title)).ToListAsync();
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
