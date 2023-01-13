using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Domain.Identity;
using Portfolio.Infra.Data.Context;
using System.Text;

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

            services.ConfigureAuthentication(configuration);
        }

        private static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddIdentityCore<User>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequiredLength = 8;
            //})
            //    .AddRoles<Role>()
            //    .AddRoleManager<RoleManager<Role>>()
            //    .AddSignInManager<SignInManager<User>>()
            //    .AddRoleValidator<RoleValidator<Role>>()
            //    .AddEntityFrameworkStores<PortfolioContext>()
            //    .AddDefaultTokenProviders();


            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTKey"])),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });
        }
    }
}
