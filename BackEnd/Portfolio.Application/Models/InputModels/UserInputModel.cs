using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Models.InputModels
{
    public class UserInputModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string NovaSenha { get; set; }
    }
}
