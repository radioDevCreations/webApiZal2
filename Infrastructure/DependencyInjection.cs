using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection")));

            services.ConfigureJwtAuthentication(configuration);
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            
            services.AddScoped<IHarboursRepository, HarboursRepository>();
            services.AddScoped<IBoatsRepository, BoatsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddScoped<IHarbourService, HarbourService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJWTService, JWTService>();

            return services;
        }
    }
}
