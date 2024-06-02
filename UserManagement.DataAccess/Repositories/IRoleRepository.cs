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

        Task<GetRoleByIdResponse> GetRoleById(int Id);

        Task<UpdateRoleResponse> UpdateRole(UpdateRoleRequest request);

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

        public async Task<GetRoleByIdResponse> GetRoleById(int Id)
        {
            var role = await _context.Roles.FindAsync(Id);

            return new GetRoleByIdResponse(role.Title);

        }

        public async Task<UpdateRoleResponse> UpdateRole(UpdateRoleRequest request)
        {
            var role = await _context.Roles.FindAsync(request.Id);

            role.Title = request.Title;

            return new UpdateRoleResponse(IsSuccess: true);

        }
    }
}
