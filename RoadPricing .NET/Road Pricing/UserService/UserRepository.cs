using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.DTO;
using UserService.Interfaces;
using UserService.Models;
using UserService.Worker;

namespace UserService
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;
        public Hasher hasher = new();

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult?> Register(User u)
        {
            string hashWord = hasher.ComputeSha256Hash(u.Password);
            u.Password = hashWord;
            await _dbContext.Users.AddAsync(u);
            await _dbContext.SaveChangesAsync();
            return default;
        }

        public async Task<User> GetUsersByID(int id)
        {
            User user = await _dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> Login(string userName, string passWord)
        {
            string hashWord = hasher.ComputeSha256Hash(passWord);
            User user = await _dbContext.Users.Where(x => x.Username == userName
            && x.Password == hashWord).FirstOrDefaultAsync();
            return user;
        }
    }
}
