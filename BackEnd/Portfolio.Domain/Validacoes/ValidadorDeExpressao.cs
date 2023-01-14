using System.Text.RegularExpressions;

namespace Portfolio.Domain.Validacoes
{
    public class ValidadorDeExpressao
    {
        private static readonly string _urlPattern = "^(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$";

        public static bool ValidarUrl(string url)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url)) return false;

            return Regex.IsMatch(url ?? "", _urlPattern);
        }
    }
}
