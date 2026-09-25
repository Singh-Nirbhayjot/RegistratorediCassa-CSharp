using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CArticoloNonAlimentare : CArticolo
    {
        public string materiale { get; set; }

        public CArticoloNonAlimentare(long codiceBarre, string descrizione, float prezzo, string materiale) : base(codiceBarre, descrizione, prezzo)
        {
            this.materiale = materiale;
        }

        public override float Sconta()
        {
            if (materiale.ToLower() == "vetro" ||
            materiale.ToLower() == "carta" ||
            materiale.ToLower() == "plastica")
            {
                return Prezzo - ((Prezzo * 10) / 100);
            }

            return Prezzo;
        }
    }
}
