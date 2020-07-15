using Microsoft.Extensions.DependencyInjection;
using Repository.Identity;
using Service.Auth;
using Service.JWT;

namespace Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IAuth, AuthService>();
            return services;
        } 
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUser, UserRepository>();
            return services;
        }

    }
}
