using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();

        Task<Role> GetRoleById(int roleId);

        Task DeleteRole(Role role);

        Task AddRole(Role role);

        Task SaveChanges();
    }
}
