using Assignment.DTOs.User;
using Assignment.Models;

namespace Assignment.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(CreateUserDto createUser);
    }
}
