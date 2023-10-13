using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Interfaces;
using Portfolio.Infrastructure.Persistence;
using Portfolio.Infrastructure.Repositories;
using System.Data;

namespace Portfolio.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = "Data Source=LAPTOP-FB8E8RAT;Initial Catalog=portfolio;Integrated Security=True;TrustServerCertificate=True;";
        services.AddDbContext<PortfolioContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
     
        return services;
    }
}
