using AccountManager.Application.Interfaces;
using AccountManager.Application.Services;
using AccountManager.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManager.IoC;

public static class Dependencies
{
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AccountManagerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AccountManagerDb"));
        });

        services.AddScoped<ICryptService, BcryptService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
    }
}
