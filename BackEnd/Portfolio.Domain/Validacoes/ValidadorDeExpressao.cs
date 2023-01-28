using System.Text.RegularExpressions;

namespace Portfolio.Domain.Validacoes
{
    public class ValidadorDeExpressao
    {
        private static readonly string _urlPattern = @"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        private static readonly string _celularPattern = "^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$";
        private static readonly string _emailPattern = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        public static bool ValidarUrl(string? url)
        {
            return Regex.IsMatch(url ?? "", _urlPattern);
        }

        public static bool ValidarCelular(string numero)
        {
            return Regex.IsMatch(numero, _celularPattern);
        }

        public static bool ValidarEmail(string email)
        {
            return Regex.IsMatch(email, _emailPattern);
        }
    }
}
