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
        public async Task<IActionResult> Login(UserDTO userDTO)
        { 
           User user = await _userRepository.Login(userDTO.userName, userDTO.passWord);
            if(user == default || user == null) { return BadRequest(); }
            else { return Ok(user.Id);  }
            
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            await _userRepository.Register(new Models.User(registerDTO.BSN, registerDTO.userName, registerDTO.passWord));
            return Ok();
        }
    }
}