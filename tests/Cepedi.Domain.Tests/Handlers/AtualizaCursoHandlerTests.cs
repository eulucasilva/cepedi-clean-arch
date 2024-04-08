/*using NSubstitute;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Tests;

public class AtualizaCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();
    private readonly AtualizaCursoHandler _sut;

    public AtualizaCursoHandlerTests()
    {
        _sut = new AtualizaCursoHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task AtualizarCursoAsync_CursoNaoExiste_RetornaErro()
    {
        var request = new AtualizaCursoRequest(
            CursoId: 1,
            Nome: "Nome do Curso 1",
            Descricao: "Descricao do Curso 1",
            DataInicio: DateTime.UtcNow,
            DataFim: DateTime.UtcNow.AddDays(30),
            ProfessorId: 1
        );

        _cursoRepository.ObtemCursoPorIdAsync(request.CursoId).Returns(Task.FromResult<CursoEntity>(null));

        var result = await _sut.AtualizarCursoAsync(request);

        Assert.False(result.Sucesso);
        Assert.Equal("Curso informado não existe", result.Mensagem);
    }

    [Fact]
    public async Task AtualizarCursoAsync_ProfessorNaoExiste_RetornaErro()
    {
        var curso = new CursoEntity();
        var request = new AtualizaCursoRequest(
            CursoId: 1,
            Nome: "Curso 1",
            Descricao: "Descricao do Curso 1",
            DataInicio: DateTime.UtcNow,
            DataFim: DateTime.UtcNow.AddDays(30),
            ProfessorId: 2 
        );

        _cursoRepository.ObtemCursoPorIdAsync(request.CursoId).Returns(Task.FromResult(curso));
        _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId).Returns(Task.FromResult<ProfessorEntity>(null));

        var result = await _sut.AtualizarCursoAsync(request);

        Assert.False(result.Sucesso);
        Assert.Equal("Professor informado não existe", result.Mensagem);
    }

    [Fact]
    public async Task AtualizarCursoAsync_DadosValidos_CursoAtualizadoComSucesso()
    {
        var curso = new CursoEntity();
        var professor = new ProfessorEntity();
        var request = new AtualizaCursoRequest(
            CursoId: 1,
            Nome: "Curso Atualizado",
            Descricao: "Descricao atualizada do Curso",
            DataInicio: DateTime.UtcNow,
            DataFim: DateTime.UtcNow.AddDays(30),
            ProfessorId: 1
        );

        _cursoRepository.ObtemCursoPorIdAsync(request.CursoId).Returns(Task.FromResult(curso));
        _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId).Returns(Task.FromResult(professor));

        var result = await _sut.AtualizarCursoAsync(request);

        Assert.True(result.Sucesso);
        Assert.Equal("Curso alterado com sucesso", result.Mensagem);
        _cursoRepository.Received(1).AtualizaCursoAsync(Arg.Any<CursoEntity>());
    }
}*/
