using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Users.Commands;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.DataAccess.Repositories
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(int Id);

        Task AddUser(User user);

        Task UpdateUser(User NewUser);

        Task DeleteUser(int Id);

    }

    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(DatabaseContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;

        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);

        }

        public async Task DeleteUser(int Id)
        {
            var user = _context.Users.Find(Id);

            _context.Users.Remove(user);
        }



        public async Task UpdateUser(User NewUser)
        {
            var user = await _context.Users.FindAsync(NewUser.Id);


            user.FirstName = NewUser.FirstName;
            user.LastName = NewUser.LastName;
            user.UserName = NewUser.UserName;
            user.Password = NewUser.Password;


        }

    }
}
