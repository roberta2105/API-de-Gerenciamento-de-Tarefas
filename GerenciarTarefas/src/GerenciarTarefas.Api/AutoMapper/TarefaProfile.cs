using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciarTarefas.Api.Contracts.TarefaContract;
using GerenciarTarefas.Api.Domain.Models;

namespace GerenciarTarefas.Api.AutoMapper
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaRequestContract>().ReverseMap();
            CreateMap<Tarefa, TarefaResponseContract>().ReverseMap();
        }
    }
}