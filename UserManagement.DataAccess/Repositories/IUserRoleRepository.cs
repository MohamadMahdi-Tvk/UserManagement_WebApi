using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repositories;

public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAllUserRoles();

    Task<UserRole> GetUserRoleById(int id);

    Task AddUserRole(UserRole userRole);

    Task DeleteUserRole(UserRole userRole);

    Task SaveChanges();
}
