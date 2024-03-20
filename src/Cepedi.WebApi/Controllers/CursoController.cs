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
    private readonly ApplicationDbContext _context;
    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler,ICadastrarCursoHandler cadastrarCursoHandler )
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _cadastrarCursoHandler = cadastrarCursoHandler;
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

}
