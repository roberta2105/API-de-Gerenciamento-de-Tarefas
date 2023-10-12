using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GerenciarTarefas.Api.Contracts.TarefaContract;
using GerenciarTarefas.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciarTarefas.Api.Contracts;

namespace GerenciarTarefas.Api.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefaController : ControllerBase
    {
        private readonly IService<TarefaRequestContract, TarefaResponseContract, long> _tarefaService;

        public TarefaController(IService<TarefaRequestContract, TarefaResponseContract, long> tarefaService)
        {
            _tarefaService = tarefaService;
        }


        private long ObterIdUsuarioLogado()
        {
            var Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            long.TryParse(Id, out long IdUsuario);
            return IdUsuario;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Adicionar(TarefaRequestContract contrato)
        {
            try
            {
                long IdUsuario = ObterIdUsuarioLogado();
                return Created("", await _tarefaService.Adicionar(contrato, IdUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Atualizar(TarefaRequestContract contrato, long Id)
        {
            try
            {
                long IdUsuario = ObterIdUsuarioLogado();
                return Ok(await _tarefaService.Atualizar(Id, contrato, IdUsuario));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Obter()
        {
            try
            {
                long IdUsuario = ObterIdUsuarioLogado();
                return Ok(await _tarefaService.Obter(IdUsuario));

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Obter(long Id)
        {
            try
            {
                long IdUsuario = ObterIdUsuarioLogado();
                return Ok(await _tarefaService.Obter(Id, IdUsuario));
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
                long IdUsuario = ObterIdUsuarioLogado();
                await _tarefaService.Deletar(Id, IdUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}