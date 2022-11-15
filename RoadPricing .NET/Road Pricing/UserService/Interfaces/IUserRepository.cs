using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUsersByID(int id);
        Task<ActionResult> Register(User u);
        Task<User> Login(string userName, string passWord);
    }
}