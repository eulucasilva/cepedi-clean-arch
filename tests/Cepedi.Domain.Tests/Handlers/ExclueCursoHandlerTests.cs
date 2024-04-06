using NSubstitute;
using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Tests;

public class ExclueCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository;
    private readonly ExclueCursoHandler _sut; 

    public ExclueCursoHandlerTests()
    {
        _cursoRepository = Substitute.For<ICursoRepository>();
        _sut = new ExclueCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task ExclueCursoAsync_CursoNaoEncontrado_RetornaFalha()
    {
        // Arrange
        var idCursoInexistente = 999;
        _cursoRepository.ObtemCursoPorIdAsync(idCursoInexistente).Returns(Task.FromResult<CursoEntity>(null));

        // Act
        var resultado = await _sut.ExclueCursoAsync(idCursoInexistente);

        // Assert
        Assert.False(resultado.Sucesso);
        Assert.Equal("Curso não encontrado", resultado.Mensagem);
    }

    [Fact]
    public async Task ExclueCursoAsync_CursoExiste_ExcluiCursoComSucesso()
    {
        // Arrange
        var cursoExistente = new CursoEntity { Id = 1, Nome = "Curso Teste" };
        _cursoRepository.ObtemCursoPorIdAsync(cursoExistente.Id).Returns(Task.FromResult(cursoExistente));

        // Act
        var resultado = await _sut.ExclueCursoAsync(cursoExistente.Id);

        // Assert
        Assert.True(resultado.Sucesso);
        Assert.Equal($"Curso {cursoExistente.Nome} excluído com sucesso", resultado.Mensagem);
        
        await _cursoRepository.Received(1).ExclueCursoAsync(cursoExistente);
    }
}
