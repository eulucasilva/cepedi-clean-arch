namespace Cepedi.Shareable.Requests;

public record AtualizaCursoRequest(int CursoId, string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);