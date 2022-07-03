using USP.Model;

namespace UPS.Application.Contract
{
    public interface IUserService
    {
        public Task<IAsyncEnumerable<UserDto>> GetAllUsersAsync();

        public Task<IEnumerable<UserDto>> GetUser(string firstName);

        public UserDto GetUser(int id);

        public Task<int> DeleteUser(int id);

        public Task<int> AddUserAsync(UserDto userDto);

        public Task<int> UpdateUser(UserDto userDto);
    }
}
