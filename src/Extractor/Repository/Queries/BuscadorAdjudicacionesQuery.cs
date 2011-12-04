using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extractor.Model.Entity;

namespace Extractor.Repository.Queries
{
    public class BuscadorAdjudicacionesQuery : IBuscadorAdjudicacionesQuery
    {
        IAdjudicacionRepository adjudicacionRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public BuscadorAdjudicacionesQuery()
            : this(new AdjudicacionRepository())
        {
        }

        public BuscadorAdjudicacionesQuery(IAdjudicacionRepository adjudicacionRepository)
        {
            this.adjudicacionRepository = adjudicacionRepository;
        }

        public IEnumerable<Adjudicacion> GetByFilter(AdjudicacionFilter filter)
        {
            var adjudicaciones = adjudicacionRepository.All;

            if (!string.IsNullOrEmpty(filter.Entidad))
            {
                adjudicaciones = adjudicaciones.Where(x => x.Entidad.ToUpper().Contains(filter.Entidad.ToUpper()));
            }

            if (!string.IsNullOrEmpty(filter.Objeto))
            {
                adjudicaciones = adjudicaciones.Where(x => x.Objeto.ToUpper().Contains(filter.Objeto.ToUpper()));
            }
            
            if (!string.IsNullOrEmpty(filter.Proveedor))
            {
                adjudicaciones =
                    adjudicaciones.Where(
                        x => x.Licitaciones.Count(p => p.Proveedor.ToUpper().Contains(filter.Proveedor.ToUpper())) > 0);
            }
            return adjudicaciones.ToList();
        }
    }
}
