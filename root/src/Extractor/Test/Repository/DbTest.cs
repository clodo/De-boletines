using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Extractor.Model.Entity;
using Extractor.Repository;
using FizzWare.NBuilder;
using NUnit.Framework;

namespace Extractor.Test
{
    [TestFixture]
    [Ignore]
    class DbTest
    {
        [Test]
        public void DropData()
        {
            AdjudicacionRepository adjudicacionRepository = new AdjudicacionRepository();
            foreach (Adjudicacion adjudicacion in adjudicacionRepository.All)
            {
                adjudicacionRepository.Delete(adjudicacion.Id);
            }
        }

        [Test]
        public void CreateAdjudicaciones()
        {
            var generator = new UniqueRandomGenerator();

            AdjudicacionRepository adjudicacionRepository = new AdjudicacionRepository();

            var precios =
                Builder<Precio>.CreateListOfSize(100).All().WithConstructor(
                    () => new Precio("$", generator.Next(10, 100))).Build();


            var licitaciones = Builder<Licitacion>.CreateListOfSize(1)
                                .All()
                                    .With(x => x.Precio = precios.First())
                                .Build();

            var adjudicaciones = Builder<Adjudicacion>.CreateListOfSize(1)
                               .TheFirst(1)
                                   .With(x => x.Entidad = "UBA")
                                   .With(x => x.Licitaciones = licitaciones)
                               .Build();

            foreach (Adjudicacion adjudicacion in adjudicaciones)
            {
                adjudicacionRepository.Save(adjudicacion);
            }

        }
    }
}
