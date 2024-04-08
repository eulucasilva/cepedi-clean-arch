

using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain;

public class CadastrarCursoHandler : IRequestHandler<CadastrarCursoRequest, CadastrarCursoResponse>
{

    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;
    public CadastrarCursoHandler(
       ICursoRepository cursoRepository,
       IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }
    /*public async Task<CadastrarCursoResponse> CadastrarCursoAsync(CadastrarCursoRequest request)
    {


        var professor = await _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId);
        if (professor == null)
        {

            return new CadastrarCursoResponse(false, "O ID do professor informado não existe");
        }


        var curso = new CursoEntity
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ProfessorId = request.ProfessorId
        };

        await _cursoRepository.CadastrarCursoAsync(curso);

        return new CadastrarCursoResponse(true, "Curso cadastrado com sucesso");
    }*/

    public async Task<CadastrarCursoResponse> Handle(CadastrarCursoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var professor = await _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId);
            if (professor == null)
            {

                 return new CadastrarCursoResponse(0, "Professor não existe");
            }


            var curso = new CursoEntity()
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ProfessorId = request.ProfessorId
            };

            await _cursoRepository.CadastrarCursoAsync(curso);

            return new CadastrarCursoResponse(curso.Id, curso.Nome);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
