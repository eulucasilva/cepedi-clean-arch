using System.Text;
using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;

    public CursoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) => 
    await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

    public async Task CadastrarCursoAsync(CursoEntity curso)
    {
       _context.Set<CursoEntity>().Add(curso);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizaCursoAsync(CursoEntity curso){
        _context.Curso.Update(curso);
         await _context.SaveChangesAsync();
    }

    public async Task ExclueCursoAsync(CursoEntity curso)
    {
        _context.Curso.Remove(curso);
        await _context.SaveChangesAsync();
    }
}
