using System;
using System.Collections.Generic;
using System.Linq;

namespace Extractor.Model.Entity
{
    public class Adjudicacion
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string Objeto { get; set; }
        public string Texto { get; set; }

        public DateTime FechaBoletin { get; set; }
        public virtual IList<Licitacion> Licitaciones { get; set; }

        public int MeGusta { get; set; }
        public int NoMeGusta { get; set; }
        public int Revisar { get; set; }

        public decimal Precio
        {
            get
            {
                if (Licitaciones != null)
                {
                    return Licitaciones.Sum(x => x.Precio.Valor);
                }
                return 0;
            }
            set { }
        }
    }
}