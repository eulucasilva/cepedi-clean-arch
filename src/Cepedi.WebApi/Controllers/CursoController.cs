using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IMediator _mediator;


    public CursoController(ILogger<CursoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /*[HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }*/

    [HttpPost]
    [ProducesResponseType(typeof(CadastrarCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CadastrarCursoResponse>> CadastrarCursoAsync([FromBody] CadastrarCursoRequest request)
    {

       return await _mediator.Send(request);
    }

    /*[HttpPut]
    public async Task<ActionResult> AtualizaCursoAsync([FromBody] AtualizaCursoRequest request)
    {

        var resultado = await _atualizaCursoHandler.AtualizarCursoAsync(request);

        if (resultado.Sucesso)
        {
            return Ok(resultado.Mensagem);
        }
        else
        {
            return BadRequest(resultado.Mensagem);
        }
    }

    [HttpDelete("{idCurso}")]

    public async Task<ActionResult> ExcluiCursoAsync([FromRoute] int idCurso)
    {

        var resultado = await _exclueCursoHandler.ExclueCursoAsync(idCurso);

        if (resultado.Sucesso)
        {
            return Ok(resultado.Mensagem);
        }
        else
        {
            return BadRequest(resultado.Mensagem);
        }
    }*/

}
