using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Extensions;
using Portfolio.Application.FluentValidation;
using Portfolio.Application.Mapping;
using Portfolio.Infra.Data.Extensions;
using Portfolio.Infra.IoC.Extensions;
using System.Globalization;
using System.Reflection;

namespace Portfolio.Infra.IoC
{
    public static class APIDependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSwaggerDocumentation();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddPersistence(configuration);
            services.AddAplicationServices();
            services.AddRepositories();

            services.AddControllers().AddFluentValidation(conf =>
            {
                conf?.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
                conf?.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                conf.ImplicitlyValidateChildProperties = true;
            });

            services.AdicionarValidadores();

            services.ConfigureAuthentication(configuration);


            string[] allowedHosts = new string[] { "http://localhost:3000", "https://danielsanchesdev.com.br" };

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder
                        .WithOrigins(allowedHosts)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
