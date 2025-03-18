using System;
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
    }
}
