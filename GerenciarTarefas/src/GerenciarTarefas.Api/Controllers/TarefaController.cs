using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GerenciarTarefas.Api.Contracts.TarefaContract;
using GerenciarTarefas.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciarTarefas.Api.Contracts;
using ControleFacil.Api.Controllers;
using GerenciarTarefas.Api.Data.Exceptions;

namespace GerenciarTarefas.Api.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefaController : BaseController
    {
        private readonly IService<TarefaRequestContract, TarefaResponseContract, long> _tarefaService;

        public TarefaController(IService<TarefaRequestContract, TarefaResponseContract, long> tarefaService)
        {
            _tarefaService = tarefaService;
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(TarefaRequestContract contrato)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Created("", await _tarefaService.Adicionar(contrato, idUsuario));
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
        public async Task<IActionResult> Atualizar(long Id, TarefaRequestContract contrato)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _tarefaService.Atualizar(Id, contrato, idUsuario));
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Obter()
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _tarefaService.Obter(idUsuario));

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

        [HttpGet]
        [Route("{Id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long Id)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _tarefaService.Obter(Id, idUsuario));
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
                long idUsuario = ObterIdUsuarioLogado();
                await _tarefaService.Deletar(Id, idUsuario);
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