using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Extensions;
using Portfolio.Application.FluentValidation;
using Portfolio.Application.Models;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Application.Services.Interfaces;

namespace Portfolio.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get(int projetoId)
        {
            var projeto = _projetoService.ObterPeloId(projetoId);

            if (projeto == null) return BadRequest("Projeto não encontrado");

            return Ok(projeto);
        }

        [AllowAnonymous]
        [HttpGet("portfolio/{portfolioId}")]
        public IActionResult ObterLista(int portfolioId, [FromQuery] PageParams parametros, [FromQuery] bool obterInativos = false)
        {
            var projetos = _projetoService.ObterLista(portfolioId, obterInativos, parametros.termoBusca);

            var pageList = PageList<ProjetoDto>.Create(projetos, parametros.NumeroPagina, parametros.tamanhoPagina);

            return Ok(pageList);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProjetoInputModel model)
        {
            try
            {
                //var validacao = new ProjetoInputModelValidator().Validate(model);

                //if (validacao.Errors.Count > 0) return Ok(validacao.Errors);

                var projeto = _projetoService.Salvar(User.ObterIdDoUsuario(), model);
                return Ok(projeto);
            }
            catch
            {
                return BadRequest("Erro desconhecido ao salvar o projeto");
            }
        }

        [HttpPut("alterarStatus/{id}")]
        public IActionResult AlterarStatus(int id)
        {
            try
            {
                var projeto = _projetoService.AlterarStatus(User.ObterIdDoUsuario(), id);

                string response = projeto.Inativo ? "Projeto desativado com sucesso" : "Projeto ativado com sucesso";

                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
