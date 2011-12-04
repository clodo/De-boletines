namespace Extractor.Model.Entity
{
    public class Precio
    {
        public string Moneda { get; private set; }
        public decimal Valor { get; private set; }

        public Precio ()
        {
        }

        public Precio (string moneda, decimal valor)
        {
            Moneda = moneda;
            Valor = valor;
        }

        public bool Equals(Precio p)
        {
            // If parameter is null return false:
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Moneda == p.Moneda) && (Valor == p.Valor);
        }

    }
}
