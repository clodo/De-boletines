using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Extractor.Model;
using Extractor.Model.Entity;

namespace Extractor.Repository
{
    public interface IAdjudicacionRepository
    {
        IQueryable<Adjudicacion> All { get; }
        IQueryable<Adjudicacion> AllIncluding(params Expression<Func<Adjudicacion, object>>[] includeProperties);
        Adjudicacion Find(int id);
        void Delete(int id);
        void DeleteAll();
        void Save(Adjudicacion location);
    }
}
