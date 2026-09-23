using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CArticoloAlimentare : CArticolo
    {
        private int annoScadenza;
        public CArticoloAlimentare(long codiceBarre, string descrizione, float prezzo, int annoScadenza) : base(codiceBarre, descrizione, prezzo)
        {
            this.AnnoScadenza = annoScadenza;
        }
        public int AnnoScadenza
        {
            get => annoScadenza;
            set
            {
                if (value < DateTime.Now.Year)
                    throw new Exception("L'anno di scadenza non può essere passato");

                annoScadenza = value;
            }
        }
        public override float Sconta()
        {
            if (AnnoScadenza == DateTime.Now.Year)
                return Prezzo - ((Prezzo*20)/100);

            else return base.Sconta();
        }
    }
}
