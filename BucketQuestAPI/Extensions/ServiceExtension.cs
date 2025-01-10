using API.Services;
using BucketQuestAPI.Interfaces;

namespace BucketQuestAPI.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}