using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<ActionResult> Register(User u);
        Task<User> Login(string userName, string passWord);
    }
}