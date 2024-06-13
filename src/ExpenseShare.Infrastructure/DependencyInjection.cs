using ExpenseShare.Domain.Abstractions;
using ExpenseShare.Domain.Users;
using ExpenseShare.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseShare.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                var connectionString = configuration.GetConnectionString("DatabaseConnection") 
                    ?? throw new ArgumentNullException(nameof(configuration));

                x.UseSqlServer(connectionString);
            });

            services.AddScoped<IUnityOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
