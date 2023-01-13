using System;
using System.Collections.Generic;

namespace Portfolio.Domain.Validacoes.Exceptions
{
    public class DomainException : Exception
    {
        public ICollection<string> MsgErros { get; set; }


        public DomainException(ICollection<string> msgErros)
        {
            MsgErros = msgErros;
        }
    }
}
