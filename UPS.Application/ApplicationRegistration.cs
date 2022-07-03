using Microsoft.Extensions.DependencyInjection;
using UPS.Application.Contract;
using UPS.Application.Services;
using UPS.Infrastructure;

namespace UPS.Application
{
    public static class ApplicationRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterRepository();

            services.AddTransient<IUserService, UserService>();
        }
    }
}
