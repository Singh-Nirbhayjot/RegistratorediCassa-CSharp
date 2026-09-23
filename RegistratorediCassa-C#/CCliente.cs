using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CCliente
    {
        private List<CArticolo> storicoAcquisti;
        private bool tesseraFedelta;

        public CCliente(bool tesseraFedelta)
        {
            this.TesseraFedelta = tesseraFedelta;
            storicoAcquisti = new List<CArticolo>();
        }
        public bool TesseraFedelta
        {
            get => tesseraFedelta;
            set => tesseraFedelta = value;
        }
        public void SalvaAcquisti(CArticolo articolo)
        {
            storicoAcquisti.Add(articolo);
        }
        public List<CArticolo> VediStorico()
        {
            return storicoAcquisti;
        }
    }
}
