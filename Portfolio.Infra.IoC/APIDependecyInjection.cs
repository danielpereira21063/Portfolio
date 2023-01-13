using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Extensions;
using Portfolio.Infra.Data.Context;

namespace Portfolio.Infra.IoC
{
    public static class APIDependecyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PortfolioHomol");

            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x =>
                {
                    x.MigrationsAssembly(typeof(PortfolioContext).Assembly.FullName);
                });
            });


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.ConfigureApplicationAuthentication(configuration);
        }
    }
}
