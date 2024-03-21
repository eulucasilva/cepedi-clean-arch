using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public class ExclueCursoHandler : IExclueCursoHandler
{

    private readonly ICursoRepository _cursoRepository;

    public ExclueCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<ExclueCursoResponse> ExclueCursoAsync(int idCurso)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);
        if (curso == null)
        {
            return new ExclueCursoResponse(false, "Curso não encontrado");
        }


        await _cursoRepository.ExclueCursoAsync(curso);

        var mensagem = $"Curso {curso.Nome} excluído com sucesso";
        return new ExclueCursoResponse(true, mensagem);
    }
}