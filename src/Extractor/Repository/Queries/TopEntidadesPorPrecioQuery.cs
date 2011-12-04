using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extractor.Model.Entity;

namespace Extractor.Repository.Queries
{
    public class TopEntidadesPorPrecioQuery : ITopEntidadesPorPrecioQuery
    {
        IAdjudicacionRepository adjudicacionRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public TopEntidadesPorPrecioQuery()
            : this(new AdjudicacionRepository())
        {
        }

        public TopEntidadesPorPrecioQuery(IAdjudicacionRepository adjudicacionRepository)
        {
            this.adjudicacionRepository = adjudicacionRepository;
        }

        public IEnumerable<Adjudicacion> GetTop(int size)
        {
            var adjudicaciones = adjudicacionRepository.All.OrderByDescending(x => x.Precio).Take(size);

            return adjudicaciones.ToList();
        }
    }
}
