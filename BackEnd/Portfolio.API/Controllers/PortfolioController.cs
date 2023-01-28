using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Extensions;
using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Services.Interfaces;

namespace Portfolio.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class PortfolioController : ControllerBase
	{
		private readonly IDadosPortfolioService _dadosPortfolioService;

		public PortfolioController(IDadosPortfolioService dadosPortfolioService)
		{
			_dadosPortfolioService = dadosPortfolioService;
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
	}
}
