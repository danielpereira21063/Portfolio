using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Services.Interfaces;

namespace Portfolio.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IDadosPortfolioService _dadosPortfolioService;

        public PortfolioController(IDadosPortfolioService dadosPortfolioService)
        {
            _dadosPortfolioService = dadosPortfolioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(DadosPortfolioInputModel model)
        {
            //validar se já existe um portfólio para o usuário.
            //Caso exista, retornar uma mensagem de erro informando que não é possível criar pois já existe.

            var response = _dadosPortfolioService.Salvar(1, model);
            return Ok(response);

        }

        [HttpPut]
        public IActionResult Put(DadosPortfolioInputModel model)
        {
            return Ok(model);
        }
    }
}
