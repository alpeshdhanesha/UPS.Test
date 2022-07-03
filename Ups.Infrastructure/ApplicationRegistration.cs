using Microsoft.Extensions.DependencyInjection;
using UPS.Infrastructure.Contract;
using UPS.Infrastructure.Repository;

namespace UPS.Infrastructure
{
    public static class ApplicationRegistration
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
