using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Portfolio.Domain.Validacoes.Exceptions
{
    public class ValidadorDeRegra
    {
        private ICollection<string> _mensagensDeErro;

        private ValidadorDeRegra()
        {
            _mensagensDeErro = new List<string>();
        }

        public static ValidadorDeRegra Novo()
        {
            return new ValidadorDeRegra();
        }

        public ValidadorDeRegra Quando(bool temErro, string mensagemDeErro)
        {
            if (temErro) _mensagensDeErro.Add(mensagemDeErro);

            return this;
        }

        public void LancarExcecaoSeExistir()
        {
            if (_mensagensDeErro.Any()) throw new DomainException(_mensagensDeErro);
        }
    }
}
