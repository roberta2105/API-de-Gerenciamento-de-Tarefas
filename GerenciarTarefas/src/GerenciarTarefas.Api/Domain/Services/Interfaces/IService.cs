using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Domain.Services.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="RQ">Resquest</typeparam>
    /// <typeparam name="RS">Response</typeparam>
    /// <typeparam name="I">Identificador</typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Obter(I IdUsuario);

        Task<RS> Obter(I Id, I IdUsuario);

        Task<RS> Adicionar(RQ entidade, I IdUsuario);

        Task<RS> Atualizar(I Id, RQ entidade, I IdUsuario);

        Task Deletar(I Id, I IdUsuario);
    }
}