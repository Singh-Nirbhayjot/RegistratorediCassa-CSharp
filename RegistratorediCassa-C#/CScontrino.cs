using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CScontrino
    {
        private int importo;
        private DateTime data;
        private int id;
        public CScontrino(int importo, DateTime data, int id)
        {
            this.Importo = importo;
            this.Data = data;
            this.Id = id;
        }

        public int Importo
        {
            get => importo;
            set
            {
                if (value < 0)
                    throw new Exception("L'importo non può essere negativo");

                importo = value;
            }
        }
        public DateTime Data
        {
            get => data;
            set => data = value;
        }
        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                    throw new Exception("L'id non può essere negativo");

                id = value;
            }
        }

    }
}
