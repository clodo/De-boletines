using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extractor.Model;
using NUnit.Framework;

namespace Extractor.Test
{
    [TestFixture]
    class ExtractorAdjudicacionTest
    {
        [Test]
        public void WhenEmptyReturnTextoEmpty()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion("");
            Assert.That(extractor.GetTexto(), Is.EqualTo(""));
        }

        [Test]
        public void WhenHolaReturnTextoHola()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion("Hola");
            Assert.That(extractor.GetTexto(), Is.EqualTo("Hola"));
        }

        [Test]
        public void WhenLicitacion1ReturnEnteFuezaAerea()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"FUERZA AEREA ARGENTINA
ESTADO MAYOR GENERAL
DE LA FUERZA AEREA
INSTITUTO DE FORMACION EZEIZA
LICITACION PRIVADA Nº 01/2011
Ejercicio: 2011
Expediente Nº 2.839.989 (FAA)
Objeto de la contratación: Mantenimiento y 
reparación de Edificios y Locales del Instituto.
Clase: De Etapa Unica Nacional
Modalidad: Sin Modalidad
Acto de apertura: Lugar/Dirección: Institu-
to de Formación Ezeiza, División Economía. 
Plazos y horarios: 06 de septiembre de 2011 
a las 10:00 hs.
Adjudicación: Lugar/Dirección: Instituto de 
Formación Ezeiza, División Economía. Nom-
bre de adjudicación y fecha de adjudicación: 
Disposición de Adjudicación y Aprobación 
Nº 30/11 de fecha 15 de septiembre de 2011.
Observaciones Generales:
Firma: METEO S.A. (CUIT 
Nº 30-70754773-8):
Orden de Compra Nº 59/11.
Monto total adjudicado: Ochenta y siete mil 
novecientos ($ 87.900,00).
e. 29/11/2011 Nº 157262/11 v. 30/11/2011
");
            Assert.That(extractor.GetEntidad(), Is.EqualTo("FUERZA AEREA ARGENTINA ESTADO MAYOR GENERAL DE LA FUERZA AEREA INSTITUTO DE FORMACION EZEIZA"));
        }

        [Test]
        public void WhenLicitacion1ReturnProveedorMeteoSa()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"FUERZA AEREA ARGENTINA
ESTADO MAYOR GENERAL
DE LA FUERZA AEREA
INSTITUTO DE FORMACION EZEIZA
LICITACION PRIVADA Nº 01/2011
Ejercicio: 2011
Expediente Nº 2.839.989 (FAA)
Objeto de la contratación: Mantenimiento y 
reparación de Edificios y Locales del Instituto.
Clase: De Etapa Unica Nacional
Modalidad: Sin Modalidad
Acto de apertura: Lugar/Dirección: Institu-
to de Formación Ezeiza, División Economía. 
Plazos y horarios: 06 de septiembre de 2011 
a las 10:00 hs.
Adjudicación: Lugar/Dirección: Instituto de 
Formación Ezeiza, División Economía. Nom-
bre de adjudicación y fecha de adjudicación: 
Disposición de Adjudicación y Aprobación 
Nº 30/11 de fecha 15 de septiembre de 2011.
Observaciones Generales:
Firma: METEO S.A. (CUIT 
Nº 30-70754773-8):
Orden de Compra Nº 59/11.
Monto total adjudicado: Ochenta y siete mil 
novecientos ($ 87.900,00).
e. 29/11/2011 Nº 157262/11 v. 30/11/2011
");
            Assert.That(extractor.GetProvedor(), Has.Some.EqualTo("METEO S.A. (CUIT Nº 30-70754773-8): Orden de Compra Nº 59/11."));
        }

        [Test]
        public void WhenLicitacion2ReturnEnteFuezaAerea()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"FUERZA AEREA ARGENTINA
DIRECCION GENERAL 
DE INTENDENCIA
DIRECCION DE CONTRATACIONES
CONTRATACION DIRECTA Nº 108/2011
Objeto: Cursos de Mantenimiento de Moto-
res T-56.
Adjudicación: Resolución de adjudicación y 
aprobación Nº 8638:
Empresa: CAE USA INC.
CUIT Nº: 00-00000000-0.
S. de Gasto: U-1211004
Monto: U$S 74.076,00.
Total: U$S 74.076,00.
e. 30/11/2011 Nº 157360/11 v. 30/11/2011

");
            Assert.That(extractor.GetEntidad(), Is.EqualTo("FUERZA AEREA ARGENTINA DIRECCION GENERAL DE INTENDENCIA DIRECCION DE CONTRATACIONES"));

        }

        [Test]
        public void WhenLicitacion2ReturnProvedorCaeUsa()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"FUERZA AEREA ARGENTINA
DIRECCION GENERAL 
DE INTENDENCIA
DIRECCION DE CONTRATACIONES
CONTRATACION DIRECTA Nº 108/2011
Objeto: Cursos de Mantenimiento de Moto-
res T-56.
Adjudicación: Resolución de adjudicación y 
aprobación Nº 8638:
Empresa: CAE USA INC.
CUIT Nº: 00-00000000-0.
S. de Gasto: U-1211004
Monto: U$S 74.076,00.
Total: U$S 74.076,00.
e. 30/11/2011 Nº 157360/11 v. 30/11/2011

");

            Assert.That(extractor.GetProvedor(), Has.Some.EqualTo("CAE USA INC."));
        }

        [Test]
        public void WhenLicitacion2ReturnObjetoCursos()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"FUERZA AEREA ARGENTINA
DIRECCION GENERAL 
DE INTENDENCIA
DIRECCION DE CONTRATACIONES
CONTRATACION DIRECTA Nº 108/2011
Objeto: Cursos de Mantenimiento de Moto-
res T-56.
Adjudicación: Resolución de adjudicación y 
aprobación Nº 8638:
Empresa: CAE USA INC.
CUIT Nº: 00-00000000-0.
S. de Gasto: U-1211004
Monto: U$S 74.076,00.
Total: U$S 74.076,00.
e. 30/11/2011 Nº 157360/11 v. 30/11/2011

");
            Assert.That(extractor.GetObjeto(), Is.EqualTo("Cursos de Mantenimiento de Motores T-56."));
        }

        [Test]
        public void WhenLicitacion2ReturnNormalize()
        {
            ExtractorAdjudicacion extractor =
                new ExtractorAdjudicacion(
                    @"FUERZA AEREA ARGENTINA
DIRECCION GENERAL 
DE INTENDENCIA
DIRECCION DE CONTRATACIONES
CONTRATACION DIRECTA Nº 108/2011
Objeto: Cursos de Mantenimiento de Moto-
res T-56.
Adjudicación: Resolución de adjudicación y 
aprobación Nº 8638:
Empresa: CAE USA INC.
CUIT Nº: 00-00000000-0.
S. de Gasto: U-1211004
Monto: U$S 74.076,00.
Total: U$S 74.076,00.
e. 30/11/2011 Nº 157360/11 v. 30/11/2011

");
            Assert.That(extractor.Normalize(),
                        Has.Member(
                            "FUERZA AEREA ARGENTINA DIRECCION GENERAL DE INTENDENCIA DIRECCION DE CONTRATACIONES CONTRATACION DIRECTA Nº 108/2011"));

            Assert.That(extractor.Normalize(),
                        Has.Member(
                            "Objeto: Cursos de Mantenimiento de Motores T-56."));

            Assert.That(extractor.Normalize(),
                        Has.Member(
                            "Empresa: CAE USA INC."));
        }

        [Test]
        public void WhenLicitacion3ReturnObjeto()
        {
            ExtractorAdjudicacion extractor =
                new ExtractorAdjudicacion(
                    @"EJERCITO ARGENTINO
COLEGIO MILITAR DE LA NACION
LICITACION PUBLICA Nº 13/2011
Expediente Nº MK11-1731/5
Objeto de la contratación: Adquisición 
de Combustibles y Lubricantes para el fun-
cionamiento del Instituto en el 4to Trimestre 
2011 y 1er Trimestre 2012.
Clase: De Etapa Unica Nacional
Modalidad: Sin Modalidad
Adjudicaciones:
Orden Nº: 1
Firma: LEONARDO MAZZEO
Renglones adjudicados: 0011, 0015, 0016, 
0017, 0018.
Importe adjudicado: $ 19.906,00.
Orden Nº: 2
Firma: DISTRIBUIDORA SYNERGIA S.R.L.
Renglones adjudicados: 0003, 0005, 0006, 
0009, 0020.
Importe adjudicado: $ 19.621,45.
Orden Nº: 3
Firma: SUALIER SA
Renglones adjudicados: 0001, 0002, 0022, 
0023.
Importe adjudicado: $ 686.950,00.
Orden Nº: 4
Firma: VIMI S.A.
Renglones adjudicados: 0004, 0007, 0008, 
0010, 0012, 0013, 0014, 0021.
Importe adjudicado: $ 34.893,80.
Orden Nº: 8
Firma: CAÑUELAS GAS S.A.
Renglón adjudicado: 0019.
Importe adjudicado: $ 15.561,00.
e. 30/11/2011 Nº 154615/11 v. 30/11/2011
");
            Assert.That(extractor.GetEntidad(), Is.EqualTo("EJERCITO ARGENTINO COLEGIO MILITAR DE LA NACION"));

            Assert.That(extractor.GetObjeto(), Is.EqualTo("Adquisición de Combustibles y Lubricantes para el funcionamiento del Instituto en el 4to Trimestre 2011 y 1er Trimestre 2012."));
        }

        [Test]
        public void WhenLicitacion3ReturnNormalize()
        {
            ExtractorAdjudicacion extractor =
                new ExtractorAdjudicacion(
                    @"EJERCITO ARGENTINO
COLEGIO MILITAR DE LA NACION
LICITACION PUBLICA Nº 13/2011
Expediente Nº MK11-1731/5
Objeto de la contratación: Adquisición 
de Combustibles y Lubricantes para el fun-
cionamiento del Instituto en el 4to Trimestre 
2011 y 1er Trimestre 2012.
Clase: De Etapa Unica Nacional
Modalidad: Sin Modalidad
Adjudicaciones:
Orden Nº: 1
Firma: LEONARDO MAZZEO
Renglones adjudicados: 0011, 0015, 0016, 
0017, 0018.
Importe adjudicado: $ 19.906,00.
Orden Nº: 2
Firma: DISTRIBUIDORA SYNERGIA S.R.L.
Renglones adjudicados: 0003, 0005, 0006, 
0009, 0020.
Importe adjudicado: $ 19.621,45.
Orden Nº: 3
Firma: SUALIER SA
Renglones adjudicados: 0001, 0002, 0022, 
0023.
Importe adjudicado: $ 686.950,00.
Orden Nº: 4
Firma: VIMI S.A.
Renglones adjudicados: 0004, 0007, 0008, 
0010, 0012, 0013, 0014, 0021.
Importe adjudicado: $ 34.893,80.
Orden Nº: 8
Firma: CAÑUELAS GAS S.A.
Renglón adjudicado: 0019.
Importe adjudicado: $ 15.561,00.
e. 30/11/2011 Nº 154615/11 v. 30/11/2011
");
            Assert.That(extractor.Normalize(),
                        Has.Member(
                            "EJERCITO ARGENTINO COLEGIO MILITAR DE LA NACION LICITACION PUBLICA Nº 13/2011 Expediente Nº MK11-1731/5"));

            Assert.That(extractor.Normalize(),
                        Has.Member(
                            "Objeto de la contratación: Adquisición de Combustibles y Lubricantes para el funcionamiento del Instituto en el 4to Trimestre 2011 y 1er Trimestre 2012."));
        }

        [Test]
        public void WhenLicitacion4ReturnMultipleProveedor()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"GENDARMERIA NACIONAL 
ARGENTINA
CONTRATACION DIRECTA Nº 45/2011
POR URGENCIA
DISPOSICION DE ADJUDICACION
Nº 711/2011, del Subdirector del
Servicio Administrativo Financiero,
de fecha 24NOV11
Expediente Nº AZ 1-4109/30
Objeto: Adquisición de Equipamiento Téc-
nico para la Dirección de Policía Científica.
Oferente: TECNOELECTRIC S.R.L.
Renglón Nº: 6.
Orden de Mérito: 1
Total considerado: $ 594,00.
Fundamento: Oferta admisible y conveniente.
Oferente: PROMETIN S.A.
Renglón Nº: 4.
Orden de Mérito: 1
Total considerado: $ 8.577,00.
Fundamento: Oferta admisible y conveniente.
Monto total adjudicado: Pesos nueve mil 
ciento setenta y uno ($ 9.171,00).
Renglones declarados fracasados Nº: 1, 2, 
3, 5, 7, 8, 9, 10, 11, 12, 13, 14 y 15.
Lugar de consulta del expediente: Departa-
mento Contrataciones de Gendarmería Nacional, 
sito en Avda Antártida Argentina Nº 1480, Piso 3, 
Ciudad Autónoma de Buenos Aires, en el horario 
de 08:30 a 13:00, TE / Fax Nro 011 4310-2703.
e. 30/11/2011 Nº 158234/11 v. 30/11/2011
");
            Assert.That(extractor.GetProvedor(), Has.Some.EqualTo("TECNOELECTRIC S.R.L."));
            Assert.That(extractor.GetProvedor(), Has.Some.EqualTo("PROMETIN S.A."));
        }

        [Test]
        public void WhenLicitacion4ReturnMultiplePrecio()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"GENDARMERIA NACIONAL 
ARGENTINA
CONTRATACION DIRECTA Nº 45/2011
POR URGENCIA
DISPOSICION DE ADJUDICACION
Nº 711/2011, del Subdirector del
Servicio Administrativo Financiero,
de fecha 24NOV11
Expediente Nº AZ 1-4109/30
Objeto: Adquisición de Equipamiento Téc-
nico para la Dirección de Policía Científica.
Oferente: TECNOELECTRIC S.R.L.
Renglón Nº: 6.
Orden de Mérito: 1
Total considerado: $ 594,00.
Fundamento: Oferta admisible y conveniente.
Oferente: PROMETIN S.A.
Renglón Nº: 4.
Orden de Mérito: 1
Total considerado: $ 8.577,00.
Fundamento: Oferta admisible y conveniente.
Monto total adjudicado: Pesos nueve mil 
ciento setenta y uno ($ 9.171,00).
Renglones declarados fracasados Nº: 1, 2, 
3, 5, 7, 8, 9, 10, 11, 12, 13, 14 y 15.
Lugar de consulta del expediente: Departa-
mento Contrataciones de Gendarmería Nacional, 
sito en Avda Antártida Argentina Nº 1480, Piso 3, 
Ciudad Autónoma de Buenos Aires, en el horario 
de 08:30 a 13:00, TE / Fax Nro 011 4310-2703.
e. 30/11/2011 Nº 158234/11 v. 30/11/2011
");

            Assert.That(extractor.GetPrecio().Count(x => x.Moneda == "$" && x.Valor == 594m), Is.EqualTo(1));
            Assert.That(extractor.GetPrecio().Count(x => x.Moneda == "$" && x.Valor == 8577), Is.EqualTo(1));
        }
        [Test]
        public void WhenLicitacion5ReturnProveedorMeteoSa()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"ADMINISTRACION FEDERAL
DE INGRESOS PUBLICOS
DIRECCION REGIONAL
ADUANERA MENDOZA
CONTRATACION DIRECTA Nº 23/2011
TRAMITE SIMPLIFICADO
Expediente Nº 1-256780-11
PERIODO: OCTUBRE 2011
Objeto de la contratación: Adquisición de 
Chombas de Piqué identificatorias.
Orden de Compra Nº 4500007583
Precio total: $ 44.884,66
Proveedor: FEDERICO LOPEZ.
e. 30/11/2011 Nº 158865/11 v. 30/11/2011");

            Assert.That(extractor.GetProvedor(), Has.Some.EqualTo("FEDERICO LOPEZ."));
        }

        [Test]
        public void WhenLicitacion5ReturnNormalize()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"ADMINISTRACION FEDERAL
DE INGRESOS PUBLICOS
DIRECCION REGIONAL
ADUANERA MENDOZA
CONTRATACION DIRECTA Nº 23/2011
TRAMITE SIMPLIFICADO
Expediente Nº 1-256780-11
PERIODO: OCTUBRE 2011
Objeto de la contratación: Adquisición de 
Chombas de Piqué identificatorias.
Orden de Compra Nº 4500007583
Precio total: $ 44.884,66
Proveedor: FEDERICO LOPEZ.
e. 30/11/2011 Nº 158865/11 v. 30/11/2011");

            Assert.That(extractor.Normalize(), Has.Some.EqualTo("e. 30/11/2011 Nº 158865/11 v. 30/11/2011"));
            Assert.That(extractor.Normalize(), Has.Some.EqualTo("Proveedor: FEDERICO LOPEZ."));
        }

        [Test]
        public void WhenLicitacion5ReturnPrecio()
        {
            ExtractorAdjudicacion extractor = new ExtractorAdjudicacion(@"ADMINISTRACION FEDERAL
DE INGRESOS PUBLICOS
DIRECCION REGIONAL
ADUANERA MENDOZA
CONTRATACION DIRECTA Nº 23/2011
TRAMITE SIMPLIFICADO
Expediente Nº 1-256780-11
PERIODO: OCTUBRE 2011
Objeto de la contratación: Adquisición de 
Chombas de Piqué identificatorias.
Orden de Compra Nº 4500007583
Precio total: $ 44.884,66
Proveedor: FEDERICO LOPEZ.
e. 30/11/2011 Nº 158865/11 v. 30/11/2011");

            Assert.That(extractor.GetPrecio().Count(x => x.Moneda == "$" && x.Valor == 44884.66m), Is.EqualTo(1));
        }

        [Test]
        public void WhenLicitacion2ReturnPrecio()
        {
            ExtractorAdjudicacion extractor =
                new ExtractorAdjudicacion(
                    @"FUERZA AEREA ARGENTINA
DIRECCION GENERAL 
DE INTENDENCIA
DIRECCION DE CONTRATACIONES
CONTRATACION DIRECTA Nº 108/2011
Objeto: Cursos de Mantenimiento de Moto-
res T-56.
Adjudicación: Resolución de adjudicación y 
aprobación Nº 8638:
Empresa: CAE USA INC.
CUIT Nº: 00-00000000-0.
S. de Gasto: U-1211004
Monto: U$S 74.076,00.
Total: U$S 74.076,00.
e. 30/11/2011 Nº 157360/11 v. 30/11/2011

");
            Assert.That(extractor.GetPrecio().Count(x => x.Moneda == "U$S" && x.Valor == 74076m), Is.EqualTo(2));
        }

        [Test]
        public void WhenLicitacion6ReturnPrecio()
        {
            ExtractorAdjudicacion extractor =
                new ExtractorAdjudicacion(
                    @"
AUTORIDAD FEDERAL
DE SERVICIOS DE 
COMUNICACION AUDIOVISUAL
LICITACION PRIVADA Nº 10/2011
Expediente Nº 1918/AFSCA/2011
Objeto: Adquisición de tónner para las Impre-
soras del AFSCA.
Clase: De Etapa Unica Nacional
Modalidad: Sin Modalidad
Renglones Nº: 1, 3, 5, 6, 7, 8, 9 y 14
Item: (296)
Adjudicatario: SW ARGENTINA SRL - CUIT 
(30-71019654-7).
Precio total: $  43.062,00 (Pesos cuarenta y 
tres mil sesenta y dos).
Renglones Nº: 4 y 13
Item: (296)
Adjudicatario: SERCAP INSUMOS SRL - 
CUIT (30-70890786-9).
Precio total: $  19.484,00 (Pesos diecinueve 
mil cuatrocientos ochenta y cuatro).
Renglón Nº: 12
Item: (296)
Adjudicatario: AMERICANTEC SRL - CUIT 
(30-70749952-0).
Precio total: $ 13.710,00 (Pesos trece mil se-
tecientos diez).
Renglones Nº: 16, 17, 18, 19 y 25
Item: (296)
Adjudicatario: LOMEZ EMANUEL ALEJAN-
DRO CUIT (20-29987325-1).
Precio total: $ 5.642,86 (Pesos cinco mil seis-
cientos cuarenta y dos con 86/100).
Renglón Nº: 20
Item: (296)
Adjudicatario: FERRARI SANDRA ALICIA - 
CUIT (27-20278653-2).
Precio total: $ 9.750,00 (Pesos nueve mil se-
tecientos cincuenta).
Renglones Nº: 21, 22, 23 y 24
Item: (296)
Adjudicatario: DINATECH SA - CUIT 
(30-70783096-0).
Precio total: $ 3.425,40 (Pesos tres mil cua-
trocientos veinticinco con 40/100).
e. 01/12/2011 Nº 158830/11 v. 01/12/2011
");
            Assert.That(extractor.GetPrecio().Count(), Is.EqualTo(6));
            Assert.That(extractor.GetPrecio().Count(x => x.Moneda == "$" && x.Valor == 43062), Is.EqualTo(1));
        }

        
    }
}
