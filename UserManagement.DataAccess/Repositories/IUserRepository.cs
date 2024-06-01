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

        Task<GetUserByIdResponse> GetUserById(int Id);

        Task AddUser(User user);

        Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request);

        Task DeleteUser(int Id);

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

        public async Task DeleteUser(int Id)
        {
            var user = _context.Users.Find(Id);

            _context.Users.Remove(user);
        }


        public async Task<List<UsersResponse>> GetUsers()
        {
            return await _context.Users.Select(t => new UsersResponse(t.FirstName, t.LastName, t.InsertDate)).ToListAsync();

        }

        public async Task<GetUserByIdResponse> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return new GetUserByIdResponse(user.FirstName, user.LastName, user.UserName, user.Password, user.InsertDate);

        }

        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(request.id);


            user.FirstName = request.firstName;
            user.LastName = request.lastName;
            user.UserName = request.userName;
            user.Password = request.Password;

            return new UpdateUserResponse(true);

        }

    }
}
