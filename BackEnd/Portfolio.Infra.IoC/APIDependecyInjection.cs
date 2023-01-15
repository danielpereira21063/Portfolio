using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddPersistence(configuration);
            services.AddAplicationServices();
            services.AddRepositories();

            services.ConfigureAuthentication(configuration);

            return services;
        }
    }
}
