using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;
public class AtualizaCursoHandler : IAtualizaCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public AtualizaCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<AtualizaCursoResponse> AtualizarCursoAsync(AtualizaCursoRequest request)
    {

        var curso = await _cursoRepository.ObtemCursoPorIdAsync(request.CursoId);
        if (curso == null)
        {

            return new AtualizaCursoResponse(false, "Curso informado não existe");
        }

        var professor = await _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId);
        if (professor == null)
        {
            return new AtualizaCursoResponse(false, "Professor informado não existe");
        }

        curso.Nome = request.Nome;
        curso.Descricao = request.Descricao;
        curso.DataInicio = request.DataInicio;
        curso.DataFim = request.DataFim;
        curso.ProfessorId = request.ProfessorId;


        await _cursoRepository.AtualizaCursoAsync(curso);

        return new AtualizaCursoResponse(true, "Curso alterado com sucesso");
    }

}
