using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Identity;

namespace Portfolio.Application.Services
{
    public class AccountService : Service, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDto> AlterarDadosDaConta(UserInputModel model)
        {
            var usuario = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);

            if (usuario == null) return null;

            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

            if (!string.IsNullOrEmpty(model.NovaSenha))
            {
                var verificacaoSenha = await VerificarSenhaAsync(model.UserName, model.Password);

                if (verificacaoSenha.Succeeded)
                {
                    var result = await _userManager.ResetPasswordAsync(usuario, token, model.NovaSenha);
                }
            }

            return Mapper.Map<UserDto>(usuario);
        }

        public bool UsuarioExite(string nomeUsuario)
        {
            return _userManager.Users.Any(x => x.UserName == nomeUsuario);
        }

        public async Task<SignInResult> VerificarSenhaAsync(string nomeUsuario, string senha)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == nomeUsuario);

            return await _signInManager.CheckPasswordSignInAsync(user, senha, false);
        }
    }
}
