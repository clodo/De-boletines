using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Extractor.Model;
using Extractor.Model.Entity;

namespace Extractor.Repository
{
    public class AdjudicacionRepository : IAdjudicacionRepository
    {
        AdjudicacionContext context = new AdjudicacionContext();

        public IQueryable<Adjudicacion> All
        {
            get { return context.Adjudicaciones; }
        }

        public IQueryable<Adjudicacion> AllIncluding(params Expression<Func<Adjudicacion, object>>[] includeProperties)
        {
            IQueryable<Adjudicacion> query = context.Adjudicaciones;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Adjudicacion Find(int id)
        {
            return context.Adjudicaciones.Find(id);
        }

        public void Save(Adjudicacion location)
        {
            if (location.Id == default(int))
            {
                // New entity
                context.Adjudicaciones.Add(location);
            }
            else
            {
                // Existing entity
                context.Entry(location).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var location = context.Adjudicaciones.Find(id);
            context.Adjudicaciones.Remove(location);
            context.SaveChanges();
        }

        public void DeleteAll()
        {
            foreach (Adjudicacion adjudicacion in All.ToList())
            {
                foreach (Licitacion licitacion in adjudicacion.Licitaciones.ToList())
                {
                    context.Licitaciones.Remove(licitacion);
                }
                context.Adjudicaciones.Remove(adjudicacion);
            }
            context.SaveChanges();
        }

    }
}
