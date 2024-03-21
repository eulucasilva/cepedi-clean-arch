using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;
public interface IAtualizaCursoHandler
{
    Task<AtualizaCursoResponse> AtualizarCursoAsync (AtualizaCursoRequest request);
}

