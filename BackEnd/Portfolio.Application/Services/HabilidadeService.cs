using AutoMapper;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Interfaces.Repositories;
namespace Portfolio.Application.Services
{
    public class HabilidadeService : Service, IHabilidadeService
    {
        private readonly IHabilidadeRepository _habildidadeRepository;

        public HabilidadeService(IMapper mapper, IHabilidadeRepository habildidadeRepository) : base(mapper)
        {
            _habildidadeRepository = habildidadeRepository;
        }

        public void Salvar(HabilidadeDto habilidade)
        {
            var habilidadeBanco = _habildidadeRepository.ObterPeloId(habilidade.Id) ?? new Domain.Entities.Habilidade("","",null, habilidade.DadosPortfolioId);

            if (!string.IsNullOrEmpty(habilidade.ImagemBase64))
            {
                var logo = Convert.FromBase64String(habilidade.ImagemBase64);
                habilidadeBanco.AlterarLogo(logo);
            }

            habilidadeBanco.AlterarDescricao(habilidade.Descricao);
            habilidadeBanco.AlterarNome(habilidade.Nome);

            if (habilidadeBanco.Id == 0)
            {
                _habildidadeRepository.Adicionar(habilidadeBanco);
            }
            else
            {
                _habildidadeRepository.Atualizar(habilidadeBanco);
            }
        }
    }
}
