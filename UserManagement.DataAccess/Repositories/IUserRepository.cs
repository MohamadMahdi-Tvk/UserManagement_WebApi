using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Users.Commands;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.DataAccess.Repositories
{
    public interface IUserRepository
    {

        Task<List<UsersResponse>> GetUsers();

        Task<User> GetUserById(int userId);

        Task AddUser(User user);

        Task UpdateUser(UpdateUserRequest response);

        Task DeleteUser(int userId);

    }

    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);

        }

        public async Task DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);

            _context.Users.Remove(user);
        }


        public async Task<List<UsersResponse>> GetUsers()
        {
            return await _context.Users.Select(t => new UsersResponse(t.FirstName, t.LastName, t.InsertDate)).ToListAsync();

        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == userId);
        }

        public async Task UpdateUser(UpdateUserRequest response)
        {
            var user = await _context.Users.FindAsync(response.id);

            
            user.FirstName = response.firstName;
            user.LastName = response.lastName;
            user.UserName = response.userName;
            user.Password = response.Password;


        }

    }
}
