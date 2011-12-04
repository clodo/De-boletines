using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extractor.Model.Entity;

namespace Extractor.Repository.Queries
{
    public interface ITopEntidadesPorPrecioQuery
    {
        IEnumerable<Adjudicacion> GetTop(int size);
    }
}
