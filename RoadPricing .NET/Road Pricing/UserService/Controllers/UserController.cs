using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.DTO;
using UserService.Models;
using UserService.Interfaces;
using UserService.Worker;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public Hasher hasher = new();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("getUsers")]
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _userRepository.GetUsers();
            return users;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string passWord)
        { 
           await _userRepository.Login(userName, passWord);
           return Ok();
            
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(int bSN, string userName, string passWord)
        {
            await _userRepository.Register(new User(bSN, userName, passWord));
            return Ok();
        }
    }
}