using Microsoft.AspNetCore.Mvc;

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
    }
}
