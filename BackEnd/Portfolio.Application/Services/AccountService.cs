using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Identity;
using Portfolio.Domain.Interfaces.Repositories;

namespace Portfolio.Application.Services
{
    public class AccountService : Service, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IDadosPortfolioRepository _dadosPortfolioRepository;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IDadosPortfolioRepository dadosPortfolioRepository, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dadosPortfolioRepository = dadosPortfolioRepository;
        }

        public async Task<UserDto> AlterarDadosDaContaAsync(UserInputModel model)
        {
            try
            {
                var usuario = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);

                if (usuario == null) return null;

                var verificacaoSenha = await VerificarSenhaAsync(usuario.UserName, model.Senha);

                if (!verificacaoSenha.Succeeded) throw new Exception("Não foi possível alterar as informações do usuário. Senha incorreta!");

                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                if (!string.IsNullOrEmpty(model.NovaSenha))
                {
                    var senhaAlterada = await AlterarSenha(usuario, model, token);

                    if (!senhaAlterada) throw new Exception("Erro desconhecido ao alterar senha do usuário");
                }

                usuario.Email = model.Email;
                usuario.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(usuario);

                return Mapper.Map<UserDto>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AlterarSenha(User usuario, UserInputModel userInputModel, string token)
        {
            var result = await _userManager.ResetPasswordAsync(usuario, token, userInputModel.NovaSenha);

            return result.Succeeded;
        }

        public async Task<UserDto> ObterUsuarioAsync(string nomeUsuario)
        {
            var user = await _userManager.FindByNameAsync(nomeUsuario);

            return Mapper.Map<UserDto>(user);
        }

        public bool UsuarioExite(string nomeUsuario)
        {
            return _userManager.Users.Any(x => x.UserName == nomeUsuario);
        }

        public async Task<SignInResult> VerificarSenhaAsync(string? nomeUsuario, string senha)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == (nomeUsuario ?? ""));

            return await _signInManager.CheckPasswordSignInAsync(user, senha, false);
        }
    }
}
