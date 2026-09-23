using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CArticolo
    {
        private long codiceBarre;
        private string descrizione;
        private float prezzo;
        public CArticolo(long codiceBarre, string descrizione, float prezzo)
        {
            this.CodiceBarre = codiceBarre;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
        }
        public long CodiceBarre
        {
            get => codiceBarre;
            set
            {
                if (value < 0)
                    throw new Exception("Il codice a barre non può essere negativo");

                codiceBarre = value;
            }
        }
        public string Descrizione
        {
            get => descrizione;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("La descrizione non può essere vuota");

                descrizione = value;
            }
        }
        public float Prezzo
        {
            get => prezzo;
            set
            {
                if (value < 0)
                    throw new Exception("Il prezzo non può essere minore di 0");

                prezzo = value;
            }
        }
        public virtual float Sconta()
        {
            return Prezzo - ((Prezzo * 5)/100);
        }
    }
}
