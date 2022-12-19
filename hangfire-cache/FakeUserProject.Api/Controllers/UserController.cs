using FakeUserProject.Service.Contract;
using FakeUserProject.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeUserProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserDto userDto)
        {
            await _userService.AddUserAsync(userDto);
            return Ok(userDto);
        }


        [HttpPut()]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserDto userDto)
        {
            await _userService.UpdateUserAsync(userDto);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok("User successfully deleted.");
        }
    }

}