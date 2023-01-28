using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Models.InputModels;

namespace Portfolio.Application.FluentValidation
{
    public static class ValidatorsConfig
    {
        public static void AdicionarValidadores(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ProjetoInputModel>();
            services.AddValidatorsFromAssemblyContaining<DadosPortfolioInputModel>();
        }
    }
}
