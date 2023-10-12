using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciarTarefas.Api.Contracts;
using GerenciarTarefas.Api.Contracts.TarefaContract;
using GerenciarTarefas.Api.Domain.Models;
using GerenciarTarefas.Api.Domain.Repository;
using GerenciarTarefas.Api.Domain.Repository.Classes;
using GerenciarTarefas.Api.Domain.Repository.Repositorys;
using GerenciarTarefas.Api.Domain.Services.Interfaces;

namespace GerenciarTarefas.Api.Domain.Services.Classes
{
    public class TarefaService : IService<TarefaRequestContract, TarefaResponseContract, long>
    {
        private readonly ITarefaRepository _tarefaRepository;
        public readonly IMapper _mapper;

        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<TarefaResponseContract> Adicionar(TarefaRequestContract entidade, long IdUsuario)
        {
            var tarefa = _mapper.Map<Tarefa>(entidade);

            tarefa.IdUsuario = IdUsuario;

            tarefa = await _tarefaRepository.Adicionar(tarefa);

            return _mapper.Map<TarefaResponseContract>(tarefa);

        }

        public async Task<TarefaResponseContract> Atualizar(long Id, TarefaRequestContract entidade, long IdUsuario)
        {
            var tarefa = await ObterPorIdVinculadoAoIdUsuario(Id, IdUsuario);

            tarefa.Titulo = entidade.Titulo;
            tarefa.Descricao = entidade.Descricao;
            tarefa.StatusTarefa = entidade.StatusTarefa;

            tarefa = await _tarefaRepository.Atualizar(tarefa);

            return _mapper.Map<TarefaResponseContract>(tarefa);
        }

        public async Task Deletar(long Id, long IdUsuario)
        {
            var tarefa = await ObterPorIdVinculadoAoIdUsuario(Id, IdUsuario);

            await _tarefaRepository.Deletar(tarefa);
        }

        public async Task<IEnumerable<TarefaResponseContract>> Obter(long IdUsuario)
        {
            var tarefas = await _tarefaRepository.ObterPeloUsuario(IdUsuario);

            return tarefas.Select(tarefa => _mapper.Map<TarefaResponseContract>(tarefa));
        }

        public async Task<TarefaResponseContract> Obter(long Id, long IdUsuario)
        {
            var tarefa = await ObterPorIdVinculadoAoIdUsuario(Id, IdUsuario);

            return _mapper.Map<TarefaResponseContract>(tarefa);
        }

        private async Task<Tarefa> ObterPorIdVinculadoAoIdUsuario(long Id, long IdUsuario)
        {
            var Tarefa = await _tarefaRepository.Obter(Id);

            if (Tarefa is null || Tarefa.IdUsuario != IdUsuario)
            {
                throw new Exception($"Não foi encontrado nenhuma tarefa pelo id {Id}");
            }
            return Tarefa;
        }


    }
}