using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Identity;
using System.Linq.Expressions;

namespace Portfolio.Application.Services
{
    public class AccountService : Service, IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<UserDto> AlterarDadosDaContaAsync(UserInputModel model)
        {
            try
            {
                var usuario = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);

                if (usuario == null) return null;

                var verificacaoSenha = await VerificarSenhaAsync(usuario.UserName, model.Senha);

                if (!verificacaoSenha.Succeeded)
                {
                    throw new Exception("Não foi possível alterar as informações do usuário. Senha incorreta!");
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                if (!string.IsNullOrEmpty(model.NovaSenha))
                {
                    var senhaAlterada = await AlterarSenha(usuario, model, token);

                    if (!senhaAlterada)
                    {
                        throw new Exception("Erro desconhecido ao alterar senha do usuário");
                    }
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

        public async Task<UserDto> CriarUsuarioAdminAsync()
        {
            try
            {
                //se existir algum usuário, não poderá criar outros. Apenas o admin!!!
                if (_userManager.Users.Any()) throw new Exception("Já existe um usuário administrador cadastrado");

                var role = new Role { Name = "admin" };
                var roleResult = await _roleManager.CreateAsync(role);

                if (!roleResult.Succeeded) throw new Exception("Ocorreu um erro desconhecido ao tentar criar o perfil de administrador");

                var novoUsuario = new User
                {
                    UserName = "admin",
                    Email = "admin"
                };

                await _userManager.CreateAsync(novoUsuario, "admin1234");

                var user = await _userManager.FindByNameAsync(novoUsuario.UserName);

                await _userManager.AddToRoleAsync(user, role.Name);

                return Mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<UserDto> ObterUsuarioAsync(string nomeUsuario)
        {
            var user = await _userManager.FindByEmailAsync(nomeUsuario);

            return Mapper.Map<UserDto>(user);
        }

        public bool UsuarioExite(string nomeUsuario)
        {
            return _userManager.Users.Any(x => x.UserName == nomeUsuario);
        }

        public async Task<SignInResult> VerificarSenhaAsync(string nomeUsuario, string senha)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == nomeUsuario);

            return await _signInManager.CheckPasswordSignInAsync(user, senha, false);
        }
    }
}
