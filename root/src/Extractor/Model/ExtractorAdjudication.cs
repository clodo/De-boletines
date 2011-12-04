using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Extractor.Model.Entity;
using NUnit.Framework;

namespace Extractor.Model
{
    public class ExtractorAdjudicacion : IExtractorAdjudicacion
    {
        private string textoOriginal;
        private IEnumerable<string> lineas;

        private string[] tokenEntidad = new string[] { "LICITACION " , "CONTRATACION " };
        private string[] tokenObjeto = new string[] { "Objeto: ", "Objeto de la contratación: " };
        private string[] tokenProveedor = new string[] { "Empresa: ", "Firma: ", "Oferente: ", "Proveedor: ", "Adjudicatario: ", "Razón Social: "};
        private string[] tokenPrecio = new string[] { "U$S", "$" };

        public ExtractorAdjudicacion()
        {
            
        }

        public ExtractorAdjudicacion(string texto)
        {
            textoOriginal = texto;
            lineas = Normalize();
        }

        public void SetTexto(string texto)
        {
            textoOriginal = texto;
            lineas = Normalize();
        }

        public string GetTexto()
        {
            return textoOriginal;
        }

        public string GetEntidad()
        {
            foreach (string linea in lineas)
            {
                foreach (var token in tokenEntidad)
                {
                    if (linea.Contains(token))
                    {
                        return linea.Substring(0, linea.IndexOf(token) - 1);
                    }
                }
            }
            
            return "";
        }

        public IEnumerable<string> Normalize()
        {
            string lastLine = textoOriginal.Trim().Split('\n').Last();
            string texto = textoOriginal.Replace(lastLine, "\nfin: ultima fila");

            Regex regEx = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚº ]*:", RegexOptions.Multiline);
            int cursor = 0;
            foreach (Match match in regEx.Matches(texto))
            {
                string line = texto.Substring(cursor, match.Index - cursor);
                yield return NormalizeLine(line);
                cursor = match.Index;
            }

            yield return lastLine;
        }

        private string NormalizeLine(string line)
        {
            return line
                .Replace("-\n", "")
                .Replace("\n", " ")
                .Replace("  ", " ")
                .TrimEnd();
        }

        public string GetObjeto()
        {
            foreach (string linea in lineas)
            {
                foreach (var token in tokenObjeto)
                {
                    if (linea.Contains(token))
                    {
                        int start = linea.IndexOf(token) + token.Length;
                        int count = linea.Length - start;
                        return linea.Substring(start, count);
                    }
                }
            }
            return "";
        }

        public IEnumerable<string> GetProvedor()
        {
            foreach (string linea in lineas)
            {
                foreach (var token in tokenProveedor)
                {
                    if (linea.Contains(token))
                    {
                        int start = linea.IndexOf(token) + token.Length;
                        int count = linea.Length - start;
                        yield return linea.Substring(start, count);
                    }
                }
            }
        }

        public IEnumerable<Precio> GetPrecio()
        {
            foreach (string linea in lineas)
            {
                foreach (string token in tokenPrecio)
                {
                    if (linea.Contains(token))
                    {
                        int start = linea.IndexOf(token) + token.Length;
                        int count = linea.Length - start;

                        Regex regex = new Regex(@"[\d*\.]*,\d*");
                        string precio = regex.Match(linea.Substring(start, count)).Value;
                        decimal precioParsed;
                        if (decimal.TryParse(precio, NumberStyles.Currency, new CultureInfo("es-AR"), out precioParsed))
                        {
                            yield return new Precio(token, precioParsed);
                        }
                        else
                        {
                            yield return new Precio(token, 0);
                        }
                        
                    }
                }
            }
        }
    }
}