using System.Collections.Generic;
using System.Linq;
using Extractor.Model.Entity;

namespace Extractor.Model
{
    class AdjudicadorBuilder
    {
        private readonly IExtractorAdjudicacion extractorAdjudicacion;

        public AdjudicadorBuilder(IExtractorAdjudicacion extractorAdjudicacion)
        {
            this.extractorAdjudicacion = extractorAdjudicacion;
        }

        internal Adjudicacion Build(string texto)
        {
            IList<Licitacion> licitaciones = new List<Licitacion>();
            extractorAdjudicacion.SetTexto(texto);
            foreach (string proveedor in extractorAdjudicacion.GetProvedor())
            {
                licitaciones.Add(new Licitacion() { Proveedor = proveedor });
            }

            int i = 0;
            foreach (Precio precio in extractorAdjudicacion.GetPrecio())
            {
                if (i < licitaciones.Count)
                {
                    licitaciones[i].Precio = precio;
                    i++;
                }
            }

            for (int j = i; j < licitaciones.Count; j++)
            {
                licitaciones[j].Precio = new Precio("$", 0);
            }

            return new Adjudicacion()
                       {
                           Entidad = extractorAdjudicacion.GetEntidad(),
                           Objeto = extractorAdjudicacion.GetObjeto(),
                           Texto = texto,
                           Licitaciones = licitaciones
                       };
        }
    }
}
