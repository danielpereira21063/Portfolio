using System.Text.RegularExpressions;

namespace Portfolio.Domain.Validacoes
{
    public static class ValidadorDeExpressao
    {
        public static bool ValidarUrl(this string url)
        {
            string pattern = "^(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$";
            return Regex.IsMatch(url, pattern);
        }
    }
}
