using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Contracts
{
    public class UsuarioLoginResponse : UsuarioLoginResquest
    {
        //Email
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        //Token

    }
}