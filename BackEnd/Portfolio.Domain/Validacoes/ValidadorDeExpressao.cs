using System.Text.RegularExpressions;

namespace Portfolio.Domain.Validacoes
{
    public class ValidadorDeExpressao
    {
        private static readonly string _urlPattern = "^(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$";
        private static readonly string _celularPattern = "^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3}\\-?[0-9]{4}$";
        private static readonly string _emailPattern = "/\\S+@\\S+\\.\\S+/";

        public static bool ValidarUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url)) return false;

            return Regex.IsMatch(url, _urlPattern);
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
