using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciarTarefas.Api.Data;
using GerenciarTarefas.Api.Domain.Models;
using GerenciarTarefas.Api.Domain.Repository.Repositorys;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace GerenciarTarefas.Api.Domain.Repository.Classes
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationContext _contexto;

        public UsuarioRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
        }


        public async Task<Usuario?> Adicionar(Usuario entidade)
        {
            //Salvamos uma entidade do tipo usuario no _contexto(banco)
            await _contexto.Usuario.AddAsync(entidade);
            //Salvou as alterações no banco. 
            await _contexto.SaveChangesAsync();

            //retorna a entidade atualizada.
            return entidade;

        }

        public async Task<Usuario?> Atualizar(Usuario entidade)
        {
            // Declara-se uma variável do tipo Usuario que recebe o valor de um 
            // objeto do tipo Usuario armazenado no banco, onde o id dele, é igual ao id da
            // entidade que estou passando como referência.
            // Logo em seguida, retorne o primeiro objeto localizado ou retorne nulo.
            var entidadeBanco = _contexto.Usuario.Where(e => e.Id == entidade.Id)
            .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Usuario>(entidadeBanco);

            await _contexto.SaveChangesAsync();

            return entidadeBanco;
        }

        public async Task Deletar(Usuario entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Deleted;

            await _contexto.SaveChangesAsync();
        }
        public async Task<IEnumerable<Usuario>> Obter()
        {
            //Retorna uma lista de usuários ordenada por id.
            return await _contexto.Usuario.AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();
        }

        public async Task<Usuario?> Obter(string Email)
        {
            return await _contexto.Usuario.AsNoTracking().Where(e => e.Email == Email)
            .FirstOrDefaultAsync();
        }

        public async Task<Usuario?> Obter(long id)
        {
            return await _contexto.Usuario.AsNoTracking().Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        }


    }
}