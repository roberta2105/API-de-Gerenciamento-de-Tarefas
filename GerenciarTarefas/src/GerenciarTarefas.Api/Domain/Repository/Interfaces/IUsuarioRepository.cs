using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciarTarefas.Api.Domain.Models;

namespace GerenciarTarefas.Api.Domain.Repository.Repositorys
{
    public interface IUsuarioRepository : IRepository<Usuario, long>
    {
        Task<Usuario> Obter(string Email);
        
    }

 
}