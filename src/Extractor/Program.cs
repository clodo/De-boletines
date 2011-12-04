using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Extractor.Model;
using Extractor.Model.Entity;
using Extractor.Repository;

namespace Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            BoletinFileName boletinFileName = new BoletinFileName(args[0]);

            Boletin boletin;
            //using (var streamReader = new StreamReader(@"C:\Documents and Settings\Administrador\Mis documentos\Visual Studio 2010\Projects\boletin\material\BO20111201-3.txt"))
            using (var streamReader = new StreamReader(boletinFileName.FilePath))
            {
                boletin = new Boletin(streamReader.ReadToEnd());
            }

            AdjudicadorBuilder adjudicadorBuilder = new AdjudicadorBuilder(new ExtractorAdjudicacion());
            AdjudicacionRepository adjudicacionRepository = new AdjudicacionRepository();

            var modulos = boletin.GetModulosSeccion(BoletinSeccion.Adjudicaciones);
            foreach(var modulo in modulos)
            {
                Adjudicacion adjudicacion = adjudicadorBuilder.Build(modulo);
                adjudicacion.FechaBoletin = boletinFileName.GetDate();
                adjudicacionRepository.Save(adjudicacion);
            }
        }
    }
}
