using System.Collections.Generic;
using Extractor.Model.Entity;

namespace Extractor.Model
{
    public interface IExtractorAdjudicacion
    {
        void SetTexto(string texto);
        string GetTexto();
        string GetEntidad();
        string GetObjeto();
        IEnumerable<string> GetProvedor();
        IEnumerable<Precio> GetPrecio();
    }
}