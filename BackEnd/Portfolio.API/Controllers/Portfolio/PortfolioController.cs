using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Models.UpdateModels;

namespace Portfolio.API.Controllers.Portfolio
{
    //[Authorize]
    [Route("api/[controller]")]
    public class PortfolioController : MainController
    {
        public PortfolioController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] DadosPortfolioInputModel model)
        {
            //validar se já existe um portfólio para o usuário.
            //Caso exista, retornar uma mensagem de erro informando que não é possível criar pois já existe.
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody] DadosPortfolioUpdateModel model)
        {
            return Ok(model);
        }
    }
}
