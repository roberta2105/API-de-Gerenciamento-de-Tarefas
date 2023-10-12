using System.Security.Authentication;
using ControleFacil.Api.Controllers;
using GerenciarTarefas.Api.Contracts;
using GerenciarTarefas.Api.Data.Exceptions;
using GerenciarTarefas.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarTarefas.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : BaseController
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
            catch (AuthenticationException ex)
            {
                return Unauthorized(RetornarModelUnauthorized(ex));
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
            catch (NotFoundException ex)
            {
                return NotFound(RetornarModelNotFound(ex));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(RetornarModelBadRequest(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{Id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(long Id, UsuarioRequestContract contrato)
        {
            try
            {
                return Ok(await _usuarioService.Atualizar(Id, contrato, 0));
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornarModelNotFound(ex));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(RetornarModelBadRequest(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        // Obter todos
        [HttpGet]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Obter(long Id)
        {
            try
            {
                return Ok(await _usuarioService.Obter(Id, 0));
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornarModelNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(long Id)
        {
            try
            {
                await _usuarioService.Deletar(Id, 0);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornarModelNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}