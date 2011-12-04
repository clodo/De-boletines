using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Extractor.Model;
using Extractor.Model.Entity;

namespace Extractor.Repository
{
    public class AdjudicacionContext : DbContext
    {
        public DbSet<Adjudicacion> Adjudicaciones { get; set; }
        public DbSet<Licitacion> Licitaciones { get; set; }
    }
}
