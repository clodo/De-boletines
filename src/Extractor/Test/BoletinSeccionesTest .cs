using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Extractor.Model;

namespace Extractor.Test
{
    [TestFixture]
    class BoletinSeccionesTest
    {
        private string inputBoletinTextPartial;
        private string inputBoletinText;

        [SetUp]
        public void Setup()
        {
            this.inputBoletinTextPartial = @"sa, sita en la calle Pringles Nº 594 (C.P. 3600) 
Ciudad de Formosa, Provincia del mismo 
nombre. Plazo y horario: El 21 de diciembre 
de 2011 a las 11:00 hs.
e. 29/11/2011 Nº 152728/11 v. 30/11/2011
% 23 % #F4281795F#
Adjudicaciones
#I4284951I# % 23 % #N157178/11N#
BANCO DE LA NACION ARGENTINA
AREA COMPRAS Y CONTRATACIONES";

            this.inputBoletinText = @"sa, sita en la calle Pringles Nº 594 (C.P. 3600) 
Ciudad de Formosa, Provincia del mismo 
nombre. Plazo y horario: El 21 de diciembre 
de 2011 a las 11:00 hs.
e. 29/11/2011 Nº 152728/11 v. 30/11/2011
% 23 % #F4281795F#
Servicios Tres Palabras
Audiovisuales
#I4284951I# % 23 % #N157178/11N#
BLOQUE1
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE2
% 23 % #F4281795F#
Adjudicaciones
#I4284951I# % 23 % #N157178/11N#
BANCO DE LA NACION ARGENTINA
AREA COMPRAS Y CONTRATACIONES
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE1
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE2
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE3
% 23 % #F4281795F#
Dictámenes de
Evaluación
#I4284951I# % 23 % #N157178/11N#
BANCO DE LA NACION ARGENTINA
BANCO PIRULO
% 19 % #F4285852F#
Locaciones
INMUEBLES (LOC)
#I4286379I# % 19 % #N159046/11N#
AFIP";

        }

        [Test]
        public void TieneSeccionAdjudicaciones()
        {
            var boletin = new Boletin(inputBoletinText);

            bool tieneSeccionAdjudicaciones = boletin.TieneSeccion(BoletinSeccion.Adjudicaciones);

            Assert.AreEqual(tieneSeccionAdjudicaciones, true);
        }

        [Test]
        public void TieneSeccionDictamenesDeEvaluacion()
        {
            var boletin = new Boletin(inputBoletinText);

            bool tieneSeccionDictamenesDeEvaluacion = boletin.TieneSeccion(BoletinSeccion.Dictamenes);

            Assert.AreEqual(tieneSeccionDictamenesDeEvaluacion, true);
        }

        [Test]
        public void TieneSeccionServicios()
        {
            var boletin = new Boletin(inputBoletinText);

            bool tieneSeccionServicios= boletin.TieneSeccion(BoletinSeccion.Servicios);

            Assert.AreEqual(tieneSeccionServicios, true);
        }

        [Test]
        public void TieneSeccionLocaciones()
        {
            var boletin = new Boletin(inputBoletinText);

            bool tieneSeccionLocaciones = boletin.TieneSeccion(BoletinSeccion.Locaciones.Inmuebles);

            Assert.AreEqual(tieneSeccionLocaciones, true);
        }

        [Test]
        public void NoTieneSeccionAdjudicaciones()
        {
            this.inputBoletinText = this.inputBoletinText.Replace("Adjudicaciones", "Preadjudicaciones");
            var boletin = new Boletin(inputBoletinText);

            bool tieneSeccionAdjudicaciones = boletin.TieneSeccion(BoletinSeccion.Adjudicaciones);

            Assert.AreEqual(tieneSeccionAdjudicaciones, false);
        }

        
        [Test]
        public void GetDesdeCopeteSeccionAdjudicaciones()
        {

            var boletin = new Boletin(inputBoletinTextPartial);

            var desdeAdjudicaciones = "";
            if (boletin.TieneSeccion(BoletinSeccion.Adjudicaciones))
            {
                desdeAdjudicaciones = boletin.GetDesdeCopete(BoletinSeccion.Adjudicaciones);
            }

            Assert.AreEqual(desdeAdjudicaciones, @"
BANCO DE LA NACION ARGENTINA
AREA COMPRAS Y CONTRATACIONES");
        }

        [Test]
        public void GetDesdeCopeteSeccionDictamenesDeEvaluacion()
        {

            var boletin = new Boletin(inputBoletinText);

            var desdeDictamenesDeEvaluacion = "";
            if (boletin.TieneSeccion(BoletinSeccion.Dictamenes))
            {
                desdeDictamenesDeEvaluacion = boletin.GetDesdeCopete(BoletinSeccion.Dictamenes);
            }

            Assert.AreEqual(desdeDictamenesDeEvaluacion, @"
BANCO DE LA NACION ARGENTINA
BANCO PIRULO
% 19 % #F4285852F#
Locaciones
INMUEBLES (LOC)
#I4286379I# % 19 % #N159046/11N#
AFIP");
        }

        [Test]
        public void GetDesdeCopeteSeccionAdjudicaciones_NoHayCopeteDeAdjudicaciones()
        {
            this.inputBoletinText = this.inputBoletinText.Replace("Adjudicaciones", @"#I4284951I# % 23 % #N157178/11N#\nAdjudicaciones");
 
            var boletin = new Boletin(inputBoletinText);

            var desdeAdjudicaciones = "";
            if (boletin.TieneSeccion(BoletinSeccion.Adjudicaciones))
            {
                desdeAdjudicaciones = boletin.GetDesdeCopete(BoletinSeccion.Adjudicaciones);
            }

            Assert.IsEmpty(desdeAdjudicaciones);
        }

        [Test]
        public void GetProximoCopeteSeccion()
        {
            var boletin = new Boletin(inputBoletinText);

            var proximoCopete = boletin.GetProximoCopete(inputBoletinText);

            Assert.AreEqual(proximoCopete, @"% 23 % #F4281795F#
Servicios Tres Palabras
Audiovisuales
#I4284951I# % 23 % #N157178/11N#");
        }

        [Test]
        public void GetSeccionAdjudicaciones()
        {
            var boletin = new Boletin(inputBoletinText);

            var seccionAdjudicaciones = "";
            if (boletin.TieneSeccion(BoletinSeccion.Adjudicaciones))
            {
                seccionAdjudicaciones = boletin.GetSeccion(BoletinSeccion.Adjudicaciones);
            }

            Assert.AreEqual(seccionAdjudicaciones, @"
BANCO DE LA NACION ARGENTINA
AREA COMPRAS Y CONTRATACIONES
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE1
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE2
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE3
");
        }

        [Test]
        public void GetSeccionDictamenesDeEvaluacion()
        {
            var boletin = new Boletin(inputBoletinText);

            var seccionDictamenesDeEvaluacion = "";
            if (boletin.TieneSeccion(BoletinSeccion.Dictamenes))
            {
                seccionDictamenesDeEvaluacion = boletin.GetSeccion(BoletinSeccion.Dictamenes);
            }

            Assert.AreEqual(@"
BANCO DE LA NACION ARGENTINA
BANCO PIRULO
", seccionDictamenesDeEvaluacion);
        }

        [Test]
        public void GetSeccionServicios()
        {
            var boletin = new Boletin(inputBoletinText);

            var seccionServicios = "";
            if (boletin.TieneSeccion(BoletinSeccion.Servicios))
            {
                seccionServicios = boletin.GetSeccion(BoletinSeccion.Servicios);
            }

            Assert.AreEqual(@"
BLOQUE1
% 23 % #F4285033F#
#I4285622I# % 23 % #N158007/11N#
BLOQUE2
", seccionServicios);
        }

        [Test]
        public void GetCollecionModulosSeccionAdjudicaciones()
        {
            var boletin = new Boletin(inputBoletinText);

            IEnumerable<string> coleccionModulos = boletin.GetModulosSeccion(BoletinSeccion.Adjudicaciones);

            Assert.AreEqual(coleccionModulos.Count(), 4);
            Assert.IsTrue(coleccionModulos.ElementAt(0).Contains("BANCO DE LA NACION ARGENTINA"));
            Assert.IsTrue(coleccionModulos.ElementAt(2).Contains("BLOQUE2"));
        }

        [Test]
        public void GetCollecionModulosSeccionDictamenesDeEvaluacion()
        {
            var boletin = new Boletin(inputBoletinText);

            IEnumerable<string> coleccionModulos = boletin.GetModulosSeccion(BoletinSeccion.Dictamenes);

            Assert.AreEqual(1, coleccionModulos.Count());
        }


        [Test]
        public void GetCollecionModulosSeccionServicios()
        {
            var boletin = new Boletin(inputBoletinText);

            IEnumerable<string> coleccionModulos = boletin.GetModulosSeccion(BoletinSeccion.Servicios);

            Assert.AreEqual(2, coleccionModulos.Count());
        }
    }
}
