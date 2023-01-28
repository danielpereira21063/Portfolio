using FluentValidation;
using Portfolio.Application.Models.InputModels;
using Portfolio.Domain.Validacoes;
using Portfolio.Domain.Validacoes.MensagemDeErros;

namespace Portfolio.Application.FluentValidation
{
    public class ProjetoInputModelValidator : AbstractValidator<ProjetoInputModel>
    {
        public ProjetoInputModelValidator()
        {
            RuleFor(x => x.Titulo)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Descricao)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(250);

            RuleFor(x => x.Url)
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(250)
                .Must(UrlValida)
                .WithMessage(ProjetoMsgErros.URL_INVALIDA);

            RuleFor(x => x.UrlGitHub)
                .NotNull().MinimumLength(1)
                .MaximumLength(250)
                .Must(UrlValida)
                .WithMessage(ProjetoMsgErros.URL_GITHUB_INVALIDA);
        }

        public bool UrlValida(ProjetoInputModel model, string url)
        {
            return ValidadorDeExpressao.ValidarUrl(url);
        }
    }
}