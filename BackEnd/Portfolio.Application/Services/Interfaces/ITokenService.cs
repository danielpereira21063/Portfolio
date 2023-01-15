using Portfolio.Application.Models.DTOs;

namespace Portfolio.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GerarTokenAsync(UserDto user);
    }
}
