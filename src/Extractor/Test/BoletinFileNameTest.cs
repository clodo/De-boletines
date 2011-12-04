using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extractor.Model;
using NUnit.Framework;

namespace Extractor.Test
{
    [TestFixture]
    class BoletinFileNameTest
    {
        [Test]
        public void WhenShortNameGetFecha()
        {
            BoletinFileName boletinFileName = new BoletinFileName("BO20111130-3.txt");
            Assert.That(boletinFileName.GetDate(), Is.EqualTo(new DateTime(2011,11,30)));
        }

        [Test]
        public void WhenLongNameGetFecha()
        {
            BoletinFileName boletinFileName = new BoletinFileName(@"C:\Documents and Settings\Administrador\Mis documentos\Visual Studio 2010\Projects\boletin\material\BO20111130-3.txt");
            Assert.That(boletinFileName.GetDate(), Is.EqualTo(new DateTime(2011, 11, 30)));
        }
    }
}
