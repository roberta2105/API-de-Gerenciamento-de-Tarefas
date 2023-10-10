using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Contracts
{
    public class UsuarioRequestContract : UsuarioLoginResquest
    {
        //Email e senha
        public string Nome { get; set; } = string.Empty;

    }
}