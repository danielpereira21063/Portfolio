using System.Security.Claims;

namespace Portfolio.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string ObterNomeUsuario(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int ObterIdDoUsuario(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
