using Assignment.DTOs.User;
using Assignment.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserRequestDto)
        {
            var user = await _userRepository.CreateUser(createUserRequestDto);
            return Ok(user);
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] CreateUserRequestDto createUserRequestDto)
        {
            var user = await _userRepository.UpdateUserAsync(id, createUserRequestDto);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }   */

    }
}
