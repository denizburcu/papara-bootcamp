using AutoMapper;
using FakeUserProject.Data.Contract;
using FakeUserProject.Data.Models;
using FakeUserProject.Service.Contract;
using FakeUserProject.Service.Helpers;
using FakeUserProject.Service.Models;

namespace FakeUserProject.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var mappedUser = _mapper.Map<User>(userDto);
            await _repository.AddAsync(mappedUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _repository.RetriveAsync(id);
            if (user == null)
                throw new UserNotFoundException($"{id} user couldnt find");

            await _repository.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var userList = await _repository.RetriveAllAsync();
            var userMappedList = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userList);
            return userMappedList.ToList();
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _repository.RetriveAsync(id);
            if (user == null)
                throw new UserNotFoundException("User couldnt find");

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await _repository.RetriveAsync(userDto.Guid);
            if (user == null)
                throw new UserNotFoundException("Update user couldnt find");

            user = _mapper.Map<User>(userDto);
            await _repository.UpdateAsync(user);
        }
    }
}