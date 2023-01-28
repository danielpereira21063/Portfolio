using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;

namespace Portfolio.Application.Services.Interfaces
{
    public interface IProjetoService
    {
        ICollection<ProjetoDto> ObterLista(int dadosPortfolioId);
        ProjetoDto ObterPeloId(int projetoId);
        ProjetoDto Salvar(int usuarioId, ProjetoInputModel model);
        ProjetoDto AlterarStatus(int usuarioId, int projetoId);
    }
}
