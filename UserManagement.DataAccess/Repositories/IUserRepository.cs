using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Users;

namespace UserManagement.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<List<GetUsersResponse>> GetAllUsers();

        Task<User> GetUserById(int userId);

        Task AddUser(User user);

        Task DeleteUser(int userId);

        Task SaveChangesAsync();
    }
}
