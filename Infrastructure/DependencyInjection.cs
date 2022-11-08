using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InitiumDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IColaRepository, ColaRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
        }
    }
}
