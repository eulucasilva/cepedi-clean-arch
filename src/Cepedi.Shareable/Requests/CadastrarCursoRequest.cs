namespace Cepedi.Shareable.Requests;
public record CadastrarCursoRequest (string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);