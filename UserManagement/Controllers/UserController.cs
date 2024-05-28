using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.ViewModels.Users;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;


        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            await userRepository.AddUser(new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                UserName = request.UserName,
            });

            await userRepository.SaveChangesAsync();
            //var model = request with { FirstName = "ali" };
            //request.FirstName = "";

            return Ok("successed!");
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userRepository.GetAllUsers());
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete(int userId)
        {
            await userRepository.DeleteUser(userId);

            await userRepository.SaveChangesAsync();
            return Ok("Success!!");
        }

        [HttpGet]
        [Route(nameof(GetUserById))]
        public async Task<IActionResult> GetUserById(int userId)
        {
            return Ok(await userRepository.GetUserById(userId));
        }

    }
}
