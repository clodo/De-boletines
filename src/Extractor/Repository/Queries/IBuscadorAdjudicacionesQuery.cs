using System.Collections.Generic;
using Extractor.Model.Entity;

namespace Extractor.Repository.Queries
{
    public interface IBuscadorAdjudicacionesQuery
    {
        IEnumerable<Adjudicacion> GetByFilter(AdjudicacionFilter filter);
    }
}