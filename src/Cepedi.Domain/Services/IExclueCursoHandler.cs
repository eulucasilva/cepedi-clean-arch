using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public interface IExclueCursoHandler
{
    Task<ExclueCursoResponse> ExclueCursoAsync(int idCurso);
}
