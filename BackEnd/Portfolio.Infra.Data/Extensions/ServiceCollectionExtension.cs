using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;
using Portfolio.Infra.Data.Repositories;
using Portfolio.Infra.Data.Transaction;

namespace Portfolio.Infra.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDadosPortfolioRepository, DadosPortfolioRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IHabilidadeRepository, HabilidadeRepository>();
        }

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Portfolio");

            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x =>
                {
                    x.MigrationsAssembly(typeof(PortfolioContext).Assembly.FullName);
                });
            });
        }
    }
}
