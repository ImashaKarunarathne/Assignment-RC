using Assignment.Data;
using Assignment.DTOs.User;
using Assignment.Interfaces;
using Assignment.Mappers;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(CreateUserDto createUser)
        {
            await _context.Users.AddAsync(createUser.CreateUserToUser());
            await _context.SaveChangesAsync();

            return createUser.CreateUserToUser();
        }
    }
}
