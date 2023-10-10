using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciarTarefas.Api.Domain.Models;

namespace GerenciarTarefas.Api.Domain.Repository.Repositorys
{
    public interface ITarefaRepository : IRepository<Tarefa, long>
    {
        Task<IEnumerable<Tarefa>> ObterPeloUsuario(long idUsuario);
        
    }

 
}