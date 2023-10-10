using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Contracts.TarefaContract
{
    public class TarefaRequestContract
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string StatusTarefa { get; set; } = string.Empty;
    }
}