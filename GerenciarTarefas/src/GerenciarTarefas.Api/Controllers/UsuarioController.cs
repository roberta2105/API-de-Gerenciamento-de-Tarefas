using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciarTarefas.Api.Contracts;
using GerenciarTarefas.Api.Domain.Services.Classes;
using GerenciarTarefas.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GerenciarTarefas.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost] //HttpPost > Cadastrando algo no banco
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(UsuarioLoginRequest contrato)
        {
            try
            {   //Create > Envia um código HTTP 201 > Indicando que a entidade foi criada com sucesso.
                return Ok(await _usuarioService.Autenticar(contrato));
            }
            catch (Exception ex)
            {  //Retorna um código HTTP 500 indicando um erro no código.
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Adicionar(UsuarioRequestContract contrato)
        {
            try
            {
                return Created("", await _usuarioService.Adicionar(contrato, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Atualizar(long Id, UsuarioRequestContract contrato)
        {
            try
            {
                return Ok(await _usuarioService.Atualizar(Id, contrato, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        // Obter todos
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Obter()
        {
            try
            {
                return Ok(await _usuarioService.Obter(0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        //Obter por id
        [HttpGet]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Obter(long Id)
        {
            try
            {
                return Ok(await _usuarioService.Obter(Id, 0));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Deletar(long Id)
        {
            try
            {
                await _usuarioService.Deletar(Id, 0);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}