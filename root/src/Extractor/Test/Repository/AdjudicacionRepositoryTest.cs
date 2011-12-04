using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extractor.Model;
using Extractor.Model.Entity;
using Extractor.Repository;
using NUnit.Framework;

namespace Extractor.Test
{
    
    [TestFixture]
    [Ignore]
    class AdjudicacionRepositoryTest
    {
        [Test]
        public void Save()
        {
            IAdjudicacionRepository repository = new AdjudicacionRepository();

            IList<Licitacion> licitaciones = new List<Licitacion>();
            licitaciones.Add(new Licitacion() { Proveedor = "Muebleria", Precio = new Precio("$", 1)});
            licitaciones.Add(new Licitacion() { Proveedor = "Carpinteria", Precio = new Precio("$", 2) });

            Adjudicacion adjudicacion = new Adjudicacion()
                                        {
                                            Entidad = "UBA",
                                            Objeto = "mesas",
                                            Texto = "hola",
                                            Licitaciones = licitaciones
                                        };

            repository.Save(adjudicacion);
        }
    }
}
