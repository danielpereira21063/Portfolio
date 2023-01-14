using Portfolio.Domain.Validacoes.Exceptions;
using Xunit;

namespace Portfolio.Domain.Test.Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this DomainException exception, string mensagem)
        {
            if (exception.MsgErros.Contains(mensagem))
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem: {mensagem}");
            }
        }
    }
}
