using Microsoft.Extensions.Configuration;
using UPS.Infrastructure.Contract;
using USP.Model;

namespace UPS.Infrastructure.Repository
{
    internal class UserRepository : ApplicationDbContext, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddUserAsync(UserDto userDto)
        {
            await Users.AddAsync(userDto);
            return await this.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(int id)
        {
            var user = Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user != null)
            {
                Users.Remove(user);
                return await this.SaveChangesAsync();
            }
            return 0;
        }

        public Task<IAsyncEnumerable<UserDto>> GetAllUsersAsync()
        {
            return Task.FromResult(Users.AsAsyncEnumerable());
        }

        public Task<IEnumerable<UserDto>> GetUser(string firstName)
        {
            return Task.FromResult(Users.Where(x => string.Equals(x.FirstName, firstName, StringComparison.OrdinalIgnoreCase)).AsEnumerable());
        }

        public UserDto GetUser(int id)
        {
            return Users.Where(x => x.UserId == id).AsQueryable().FirstOrDefault();
        }

        public async Task<int> UpdateUser(UserDto userDto)
        {
            var user = Users.FirstOrDefault(x => x.UserId == userDto.UserId);
            if (user != null)
            {
                user.UserName = userDto.UserName;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Address = userDto.Address;
                user.Contact = userDto.Contact;
                Users.Update(user);
                return await this.SaveChangesAsync();
            }
            return 0;

        }
    }
}
