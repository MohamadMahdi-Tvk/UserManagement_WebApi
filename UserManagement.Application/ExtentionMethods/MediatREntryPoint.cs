using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using UserManagement.DataAccess.Connections;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.UnitOfWork;

namespace UserManagement.Application.ExtentionMethods;

public static class MediatREntryPoint
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetService<ILogger<UserRepository>>();
        services.AddSingleton(typeof(ILogger), logger);
        services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();
        services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IPostRepository,PostRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
