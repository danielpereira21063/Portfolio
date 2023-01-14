using System.Collections.Generic;
using System.Linq;
using Portfolio.Domain.Validacoes.Exceptions;

namespace Portfolio.Domain.Validacoes
{
    public class ValidadorDeEntidade
    {
        private ICollection<string> _mensagensDeErro;

        private ValidadorDeEntidade()
        {
            _mensagensDeErro = new List<string>();
        }

        public static ValidadorDeEntidade Novo()
        {
            return new ValidadorDeEntidade();
        }

        public ValidadorDeEntidade Quando(bool temErro, string mensagemDeErro)
        {
            if (temErro) _mensagensDeErro.Add(mensagemDeErro);

            return this;
        }

        public void LancarExcecoesSeExistir()
        {
            if (_mensagensDeErro.Any()) throw new DomainException(_mensagensDeErro);
        }
    }
}
