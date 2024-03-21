using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly ICadastrarCursoHandler _cadastrarCursoHandler;
    private readonly IAtualizaCursoHandler _atualizaCursoHandler;
    private readonly IExclueCursoHandler _exclueCursoHandler;


    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler, ICadastrarCursoHandler cadastrarCursoHandler,
    IAtualizaCursoHandler atualizaCursoHandler, IExclueCursoHandler exclueCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _cadastrarCursoHandler = cadastrarCursoHandler;
        _atualizaCursoHandler = atualizaCursoHandler;
        _exclueCursoHandler = exclueCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }

    [HttpPost]
    public async Task<ActionResult> CadastrarCursoAsync([FromBody] CadastrarCursoRequest request)
    {

        var resultado = await _cadastrarCursoHandler.CadastrarCursoAsync(request);

        if (resultado.Sucesso)
        {
            return Ok();
        }
        else
        {
            return BadRequest(resultado.Mensagem);
        }
    }

    [HttpPut]
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
    }

}
