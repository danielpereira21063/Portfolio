using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Extensions;
using Portfolio.Application.Models.InputModels;
using Portfolio.Application.Services.Interfaces;

namespace Portfolio.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }


        [HttpGet]
        public async Task<IActionResult> ObterUsuario()
        {
            var user = await _accountService.ObterUsuarioAsync(User.ObterNomeUsuario());

            if (user == null) return Unauthorized();

            user.Token = HttpContext.ObterTokenUsuario();
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UserInputModel model)
        {
            try
            {
                if (model.UserName != User.ObterNomeUsuario()) return Unauthorized("Usuário inválido");

                var usuarioExiste = _accountService.UsuarioExite(model.UserName);

                if (!usuarioExiste) throw new Exception("Usuário não encontrado");

                var usuario = await _accountService.AlterarDadosDaContaAsync(model);

                if (usuario == null) throw new Exception("Erro ao alterar dados da conta do usuário");

                return Ok(new
                {
                    usuario = usuario.UserName,
                    token = await _tokenService.GerarTokenAsync(usuario)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginInputModel model)
        {
            var usuario = await _accountService.ObterUsuarioAsync(model.Usuario);

            if (usuario == null) return Unauthorized("Usuário ou senha incorretos");

            var result = await _accountService.VerificarSenhaAsync(model.Usuario, model.Senha);

            if (!result.Succeeded) return Unauthorized("Usuário ou senha incorretos");

            return Ok(new
            {
                usuario = usuario.UserName,
                token = await _tokenService.GerarTokenAsync(usuario)
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CriarUsuarioAdmin()
        {
            if (_accountService.UsuarioExite("admin"))
            {
                return BadRequest("Já existe um usuário administrador cadastrado");
            }

            var usuario = await _accountService.CriarUsuarioAdminAsync();

            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro desconhecido ao tentar criar o usuário administrador");
            }

            return Ok("Usuário criado com sucesso");
        }
    }
}
