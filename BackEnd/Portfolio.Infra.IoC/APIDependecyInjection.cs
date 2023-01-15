using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Portfolio.Application.Extensions;
using Portfolio.Application.Mapping;
using Portfolio.Infra.Data.Extensions;
using Portfolio.Infra.IoC.Extensions;

namespace Portfolio.Infra.IoC
{
    public static class APIDependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfólio", Version = "v1.0" });
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddPersistence(configuration);
            services.AddAplicationServices();
            services.AddRepositories();

            services.ConfigureAuthentication(configuration);

            return services;
        }
    }
}
