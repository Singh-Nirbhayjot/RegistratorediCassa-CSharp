using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CArticoloNonAlimentare : CArticolo
    {
        public Materiale materiale { get; set; }

        public CArticoloNonAlimentare(long codiceBarre, string descrizione, float prezzo, Materiale materiale) : base(codiceBarre, descrizione, prezzo)
        {
            this.materiale = materiale;
        }

        public override float Sconta()
        {
            return Prezzo - ((Prezzo*10)/100);
        }
    }
}
