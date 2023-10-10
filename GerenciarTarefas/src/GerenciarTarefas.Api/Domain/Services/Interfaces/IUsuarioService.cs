using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GerenciarTarefas.Api.Contracts;

namespace GerenciarTarefas.Api.Domain.Services.Interfaces
{
    public interface IUsuarioService : IService<UsuarioRequestContract, UsuarioResponseContract, long>
    {
        //Task<UsuarioLoginResponse> Autenticar(UsuarioLoginRequest usuarioLoginRequest);
        Task<UsuarioResponseContract> Obter(string Email);
    }
}