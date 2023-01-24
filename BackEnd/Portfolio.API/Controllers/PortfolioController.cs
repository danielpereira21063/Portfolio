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

		[HttpGet]
		public IActionResult Get()
		{
			var dadosPortfolio = _dadosPortfolioService.ObterDadosPortfolio(User.ObterIdDoUsuario());
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
