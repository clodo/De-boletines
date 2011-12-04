using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Extractor.Model
{
    public class Boletin
    {
        private string inputBoletinText;

        public Boletin(string inputBoletinText)
        {
            this.inputBoletinText = Regex.Replace(inputBoletinText, @"\r", "");
        }

        public bool TieneSeccion(string seccion)
        {
            seccion = seccion.Replace(" ", @"[\n\s]+");

            var regexStr = string.Format(@"\%\s\d*\s\%\s\#.*\#\n\s*{0}", seccion);
            var rx = new Regex(regexStr, RegexOptions.IgnoreCase);

            return rx.IsMatch(inputBoletinText);
        }

        
        public string GetDesdeCopete(string seccion)
        {
            seccion = seccion.Replace(" ", @"[\n\s]+");
            var regexStr = string.Format(@"\%\s\d*\s\%\s\#.*\#\n\s*{0}\n\#.*\#\s\%\s\d*\s\%\s\#.*\#", seccion);
            var rx = new Regex(regexStr, RegexOptions.IgnoreCase);

            return rx.IsMatch(inputBoletinText)
                       ? rx.Split(inputBoletinText)[1]
                       : string.Empty;
        }

        public string GetProximoCopete(string parteBoletin)
        {
            var rx = new Regex(@"\%\s\d*\s\%.*\n\s*\w+[\s\w\n()]*\#.*\#\s\%\s\d*\s\%\s\#.*\#", RegexOptions.IgnoreCase);

            return rx.IsMatch(parteBoletin) ? rx.Matches(parteBoletin)[0].Value : string.Empty;
        }

        public string GetSeccion(string seccion)
        {
            var desdeCopeteSeccion = this.GetDesdeCopete(seccion);

            var proximoCopete = this.GetProximoCopete(desdeCopeteSeccion);
            var indexProximoCopete = desdeCopeteSeccion.IndexOf(proximoCopete);

            return indexProximoCopete > 0
                       ? desdeCopeteSeccion.Remove(indexProximoCopete)
                       : desdeCopeteSeccion;
        }

        public IEnumerable<string>GetModulosSeccion(string seccion)
        {
            var seccionCompleta = this.GetSeccion(seccion);

            var rx = new Regex(@"\%\s\d*\s\%\s\#.*\#\n\#.*\#\s\%\s\d*\s\%\s\#.*\#", RegexOptions.IgnoreCase);

            return rx.Split(seccionCompleta);
        }
    }
}
