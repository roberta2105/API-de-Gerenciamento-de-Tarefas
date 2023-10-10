using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Contracts
{
    public class UsuarioResponseContract : UsuarioRequestContract
    {
        //Email, senha, nome
        public long Id { get; set; }
 

    }
}