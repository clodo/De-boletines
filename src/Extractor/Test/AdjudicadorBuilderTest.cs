using System.Linq;
using Extractor.Model;
using Extractor.Model.Entity;
using Moq;
using NUnit.Framework;

namespace Extractor.Test
{
    [TestFixture]
    class AdjudicadorBuilderTest
    {
        [Test]
        public void WhenLicitacion1ProveedorReturnAdjudicacion()
        {
            Mock<IExtractorAdjudicacion> extractor = new Mock<IExtractorAdjudicacion>();
            extractor.Setup(x => x.GetEntidad()).Returns("UBA");
            extractor.Setup(x => x.GetObjeto()).Returns("sillas");
            extractor.Setup(x => x.GetProvedor()).Returns(new string[] { "Muebleria" });
            extractor.Setup(x => x.GetPrecio()).Returns(new Precio[] { new Precio("$", 1), });
            AdjudicadorBuilder adjudicadorBuilderbuilder = new AdjudicadorBuilder(extractor.Object);

            Adjudicacion adjudicacion = adjudicadorBuilderbuilder.Build("hola");

            Assert.That(adjudicacion.Entidad, Is.EqualTo("UBA"));
            Assert.That(adjudicacion.Objeto, Is.EqualTo("sillas"));
            Assert.That(adjudicacion.Texto, Is.EqualTo("hola"));
            Assert.That(adjudicacion.Licitaciones.Count(), Is.EqualTo(1));
            Assert.That(adjudicacion.Licitaciones.First().Proveedor, Is.EqualTo("Muebleria"));
            Assert.That(adjudicacion.Licitaciones.First().Precio.Moneda, Is.EqualTo("$"));
            Assert.That(adjudicacion.Licitaciones.First().Precio.Valor, Is.EqualTo(1));
        }

        [Test]
        public void WhenLicitacion2ProveedoresReturnAdjudicacion()
        {
            Mock<IExtractorAdjudicacion> extractor = new Mock<IExtractorAdjudicacion>();
            extractor.Setup(x => x.GetEntidad()).Returns("UBA");
            extractor.Setup(x => x.GetObjeto()).Returns("sillas");
            extractor.Setup(x => x.GetProvedor()).Returns(new string[] { "Muebleria", "Carpinteria" });
            extractor.Setup(x => x.GetPrecio()).Returns(new Precio[] { new Precio("$", 1), new Precio("$", 2) });
            AdjudicadorBuilder adjudicadorBuilderbuilder = new AdjudicadorBuilder(extractor.Object);

            Adjudicacion adjudicacion = adjudicadorBuilderbuilder.Build("hola");

            Assert.That(adjudicacion.Entidad, Is.EqualTo("UBA"));
            Assert.That(adjudicacion.Objeto, Is.EqualTo("sillas"));
            Assert.That(adjudicacion.Texto, Is.EqualTo("hola"));
            Assert.That(adjudicacion.Licitaciones.Count(), Is.EqualTo(2));
            Assert.That(adjudicacion.Licitaciones.First().Proveedor, Is.EqualTo("Muebleria"));
            Assert.That(adjudicacion.Licitaciones.First().Precio.Moneda, Is.EqualTo("$"));
            Assert.That(adjudicacion.Licitaciones.First().Precio.Valor, Is.EqualTo(1));
            Assert.That(adjudicacion.Licitaciones.Last().Proveedor, Is.EqualTo("Carpinteria"));
            Assert.That(adjudicacion.Licitaciones.Last().Precio.Moneda, Is.EqualTo("$"));
            Assert.That(adjudicacion.Licitaciones.Last().Precio.Valor, Is.EqualTo(2));
        }
    }
}
