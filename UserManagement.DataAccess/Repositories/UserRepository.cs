using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Context;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Users;

namespace UserManagement.DataAccess.Repositories
{
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

        public async Task<List<GetUsersResponse>> GetAllUsers()
        {
            return await _context.Users.Select(p => new GetUsersResponse(p.FirstName, p.LastName, p.InsertDate, p.UserName, p.Password))
                .ToListAsync();


        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == userId);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
