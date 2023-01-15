using Microsoft.AspNetCore.Identity;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Domain.Identity;

namespace Portfolio.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<SignInResult> VerificarSenhaAsync(string nomeUsuario, string senha);
        Task<UserDto> AlterarDadosDaConta(UserInputModel user);
        bool UsuarioExite(string nomeUsuario);
    }
}
