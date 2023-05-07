using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Extensions;
using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Services.Interfaces;

namespace Portfolio.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IDadosPortfolioService _dadosPortfolioService;
        private readonly IHabilidadeService _habilidadeService;

        public PortfolioController(IDadosPortfolioService dadosPortfolioService, IHabilidadeService habilidadeService)
        {
            _dadosPortfolioService = dadosPortfolioService;
            _habilidadeService = habilidadeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            //Como só existe um usuário, busco apenas o portfólio com id 1
            var dadosPortfolio = _dadosPortfolioService.ObterDadosPortfolio(1);
            return Ok(dadosPortfolio);
        }

        [HttpPut]
        public IActionResult Put(DadosPortfolioInputModel model)
        {
            var response = _dadosPortfolioService.Salvar(User.ObterIdDoUsuario(), model);
            return Ok(response);
        }


        [HttpPut("Habilidade")]
        public IActionResult PutHabilidade(HabilidadeDto model)
        {
            var portfolio = _dadosPortfolioService.ObterDadosPortfolio(User.ObterIdDoUsuario());
            model.DadosPortfolioId = portfolio.Id;
            _habilidadeService.Salvar(model);

            return Ok("Habilidade salva com sucesso");
        }
    }
}
