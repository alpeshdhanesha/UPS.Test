using UPS.Application.Contract;
using UPS.Infrastructure.Contract;
using USP.Model;

namespace UPS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> AddUserAsync(UserDto userDto)
        {
            return await userRepository.AddUserAsync(userDto);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }

        public async Task<IAsyncEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUser(string firstName)
        {
            return await userRepository.GetUser(firstName);
        }

        public UserDto GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public async Task<int> UpdateUser(UserDto userDto)
        {
            return await userRepository.UpdateUser(userDto);
        }
    }
}
