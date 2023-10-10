using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GerenciarTarefas.Api.Contracts;
using GerenciarTarefas.Api.Domain.Models;
using GerenciarTarefas.Api.Domain.Repository.Repositorys;
using GerenciarTarefas.Api.Domain.Services.Interfaces;

namespace GerenciarTarefas.Api.Domain.Services.Classes
{
    public class UsuarioService : IUsuarioService
    {
        //Um serviço se comunica com um repositório permitindo a interação com os dados da entidade por meio de uma
        //injeção de dependência.
        private readonly IUsuarioRepository _usuarioRepository;

        //Uma injeção de dependência para mapear objetos entre
        public readonly IMapper _mapper;

        // private readonly TokenService _tokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        // TokenService tokenService
        {
            //Retorna os métodos de IUsuario e por injeção de dependência retorna as classes herdadas por essa classe
            _usuarioRepository = usuarioRepository;
            //Retorna uma entidade apartir de um RS e um RQ
            _mapper = mapper;

            //_tokenService = tokenService;
        }

        public async Task<UsuarioResponseContract> Adicionar(UsuarioRequestContract entidade, long Id)
        {
            var usuario = _mapper.Map<Usuario>(entidade);

            usuario.Senha = GerarHashSenha(usuario.Senha);

            usuario = await _usuarioRepository.Adicionar(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);

        }

        private string GerarHashSenha(string senha)
        {
            string hashSenha;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
                byte[] bytesHashSenha = sha256.ComputeHash(bytesSenha);
                hashSenha = BitConverter.ToString(bytesHashSenha).Replace("-", "").ToLower();
            }

            return hashSenha;
        }

        public async Task<UsuarioResponseContract> Atualizar(UsuarioRequestContract entidade, long Id, long IdUsuario)
        {
            _ = await Obter(Id) ?? throw new Exception("Usuário não encontrado");

            var usuario = _mapper.Map<Usuario>(entidade);

            usuario.Id = Id;
            usuario.Senha = GerarHashSenha(entidade.Senha);

            usuario = await _usuarioRepository.Atualizar(usuario);

            return _mapper.Map<UsuarioResponseContract>(usuario);

        }

        public async Task Deletar(long Id, long IdUsuario)
        {
            var usuario = await _usuarioRepository.Obter(Id) ?? throw new Exception("Usuário não encontrado para deleção");

            await _usuarioRepository.Deletar(_mapper.Map<Usuario>(usuario));
        }

        public async Task<UsuarioResponseContract> Obter(string Email)
        {
            var usuario = await _usuarioRepository.Obter(Email);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }

        public async Task<IEnumerable<UsuarioResponseContract>> Obter(long IdUsuario)
        {
            var usuarios = await _usuarioRepository.Obter();

            return usuarios.Select(usuario => _mapper.Map<UsuarioResponseContract>(usuario));
        }

        public async Task<UsuarioResponseContract> Obter(long Id, long IdUsuario)
        {
            var usuario = await _usuarioRepository.Obter(Id);

            return _mapper.Map<UsuarioResponseContract>(usuario);
        }
    }
}