using Cepedi.Domain.Entities;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task CadastrarCursoAsync(CursoEntity curso);

    Task AtualizaCursoAsync(CursoEntity curso);

    Task ExclueCursoAsync(CursoEntity curso);

}
