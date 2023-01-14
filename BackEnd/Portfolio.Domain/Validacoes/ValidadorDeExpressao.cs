using System;
using System.Text.RegularExpressions;

namespace Portfolio.Domain.Validacoes
{
    public class ValidadorDeExpressao
    {
        private static readonly string _urlPattern = "^(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$";
        private static readonly string _celularPattern = "/^(?:(?:\\+|00)?(55)\\s?)?(?:\\(?([1-9][0-9])\\)?\\s?)?(?:((?:9\\d|[2-9])\\d{3})\\-?(\\d{4}))$/";
        private static readonly string _emailPattern = "Regex(@\"^(?:(?:\\+|00)?\\s*(?:\\d{1,3})?\\s*)?(?:(?:\\d{3})?\\s*)?(?:\\d{3})?\\s*(?:\\d{4})$\");";

        public static bool ValidarUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url)) return false;

            return Regex.IsMatch(url, _urlPattern);
        }

        public static bool ValidarCelular(string numero)
        {
            //if (string.IsNullOrEmpty(numero) || string.IsNullOrWhiteSpace(numero)) return false;

            var teste = Regex.IsMatch(numero, _celularPattern);

            return Regex.IsMatch(numero, _celularPattern);
        }

        public static bool ValidarEmail(string email)
        {
            //if (string.IsNullOrEmpty(numero) || string.IsNullOrWhiteSpace(numero)) return false;

            return Regex.IsMatch(email, _emailPattern);
        }
    }
}
