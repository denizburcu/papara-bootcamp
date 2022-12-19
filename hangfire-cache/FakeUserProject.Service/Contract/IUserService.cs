using FakeUserProject.Service.Models;

namespace FakeUserProject.Service.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task AddUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
        Task<UserDto> GetUserAsync(int id);
        Task UpdateUserAsync(UserDto userDto);
    }
}