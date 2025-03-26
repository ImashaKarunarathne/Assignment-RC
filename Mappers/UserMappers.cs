using Assignment.DTOs.User;
using Assignment.Models;

namespace Assignment.Mappers
{
    public static class UserMappers
    {
        public static User CreateUserToUser(this CreateUserDto createUser)
        {
            return new User
            {
                Name = createUser.Name,
                Password = "mock passward",
                Email = createUser.Email,
                Role = 1
            };
        }
    }
}
