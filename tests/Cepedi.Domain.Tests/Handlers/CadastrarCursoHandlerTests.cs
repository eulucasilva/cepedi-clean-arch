/*using Cepedi.Data;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class CadastrarCursoHandlerTests
{
    private CadastrarCursoHandler _sut;
    private ICursoRepository _cursoRepository;
    private IProfessorRepository _professorRepository;


    public CadastrarCursoHandlerTests()
    {
        _cursoRepository = Substitute.For<ICursoRepository>();
        _professorRepository = Substitute.For<IProfessorRepository>();
        _sut = new CadastrarCursoHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task CadastrarCursoAsync_WhenProfessorDoesNotExist_ReturnsFalse()
    {

        var request = new CadastrarCursoRequest
        (
            Nome: "Curso Teste",
            Descricao: "Descrição do curso teste",
            DataInicio: DateTime.Now,
            DataFim: DateTime.Now.AddDays(30),
            ProfessorId: -1 // ID de professor que não existe
        );

        _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId).Returns(Task.FromResult<ProfessorEntity>(null));

        // Act
        var response = await _sut.CadastrarCursoAsync(request);

        // Assert
        Assert.False(response.Sucesso);
        Assert.Equal("O ID do professor informado não existe", response.Mensagem);
    }

    [Fact]
    public async Task CadastrarCursoAsync_WhenProfessorExists_ReturnsTrue()
    {
        // Arrange
        var request = new CadastrarCursoRequest
        (
            Nome: "Curso Teste",
            Descricao: "Descrição do curso teste",
            DataInicio: DateTime.Now,
            DataFim: DateTime.Now.AddDays(30),
            ProfessorId: 1 // ID de professor que existe
        );

        _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId).Returns(Task.FromResult(new ProfessorEntity()));


        // Act
        var response = await _sut.CadastrarCursoAsync(request);

        // Assert
        Assert.True(response.Sucesso);
        Assert.Equal("Curso cadastrado com sucesso", response.Mensagem);
    }
}
*/

