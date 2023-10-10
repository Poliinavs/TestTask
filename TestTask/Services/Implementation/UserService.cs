using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
Task<User> IUserService.GetUser()
        {
            Task<User> user = _context.Users.OrderByDescending(x => x.Orders.Count()).FirstOrDefaultAsync();
            return user;
        }

        Task<List<User>> IUserService.GetUsers()
        {
            Task<List<User>> users = _context.Users.Where(a => a.Status.Equals(Enums.UserStatus.Inactive)).ToListAsync();
            return users;
        }
    }
}
