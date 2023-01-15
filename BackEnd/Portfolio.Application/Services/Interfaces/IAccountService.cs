using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Domain.Identity;

namespace Portfolio.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> CriarUsuarioAdminAsync();
        Task<bool> AlterarSenha(User usuario, UserInputModel userInputModel, string token);
        Task<UserDto> ObterUsuarioAsync(string nomeUsuario);
        Task<SignInResult> VerificarSenhaAsync(string nomeUsuario, string senha);
        Task<UserDto> AlterarDadosDaContaAsync(UserInputModel user);
        bool UsuarioExite(string nomeUsuario);
    }
}
