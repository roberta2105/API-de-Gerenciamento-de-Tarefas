using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciarTarefas.Api.Data;
using GerenciarTarefas.Api.Domain.Models;
using GerenciarTarefas.Api.Domain.Repository.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace GerenciarTarefas.Api.Domain.Repository.Classes
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationContext _contexto;

        public TarefaRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Tarefa> Adicionar(Tarefa entidade)
        {
            await _contexto.Tarefa.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            return entidade;
        }

        public async Task<Tarefa> Atualizar(Tarefa entidade)
        {
            Tarefa entidadeBanco = _contexto.Tarefa.Where(e => e.Id == entidade.Id)
            .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Tarefa>(entidadeBanco);

            await _contexto.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(Tarefa entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Deleted;

            await _contexto.SaveChangesAsync();

        }

        public async Task<IEnumerable<Tarefa>> Obter()
        {
            return await _contexto.Tarefa.AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();

        }

        public async Task<Tarefa?> Obter(long id)
        {
            return await _contexto.Tarefa.AsNoTracking().Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterPeloUsuario(long IdUsuario)
        {
            return await _contexto.Tarefa.AsNoTracking().Where(n => n.IdUsuario == IdUsuario)
            .OrderBy(n => n.Id)
            .ToListAsync();
        }
    }
}