using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RegistratorediCassa_C_
{
    public class CRegistratore
    {
        private List<CScontrino> scontrini;
        private int numeroScontrino;
        private DateTime dataUltimoScontrino;
        public CRegistratore()
        {
            scontrini = new List<CScontrino>();
            numeroScontrino = 1;
            dataUltimoScontrino = DateTime.Now.Date;
        }
        public void EmettiScontrino(int imp)
        {
            DateTime data = DateTime.Now;

            if (data.Date != dataUltimoScontrino)
            {
                numeroScontrino = 1;
                dataUltimoScontrino = data.Date;
            } 

            CScontrino scontrino = new CScontrino(imp, data, numeroScontrino);
            scontrini.Add(scontrino);

            numeroScontrino++;
        }
        public void CancellaScontrino()
        {
            if(scontrini.Count > 0)
            {
                scontrini.RemoveAt(scontrini.Count - 1);
                numeroScontrino--;
            }
        }
        public List<CScontrino> ListaScontrini()
        {
            List<CScontrino> risultato = new List<CScontrino>();

            DateTime oggi = DateTime.Now.Date;
            foreach(CScontrino s in scontrini)
            {
                if (s.Data.Date == oggi)
                    risultato.Add(s);
            }
            return risultato;
        }
        public List<CScontrino> ListaPerMese(int m)
        {
            List<CScontrino> Scontrinimese = new List<CScontrino>();
                
                foreach(CScontrino s in scontrini)
                {
                    if(s.Data.Month == m)
                    {
                        Scontrinimese.Add(s);
                    }
                }
            return Scontrinimese;
        }
        public List<CScontrino> ListaPerSettimana(int settimana)
        {
            List<CScontrino> settimane = new List<CScontrino>();
                foreach(CScontrino s in scontrini)
                {
                    int settimanaScontrino = (s.Data.DayOfYear - 1) / 7 + 1;
                    if (settimanaScontrino == settimana)
                    {
                        settimane.Add(s);
                    }
                }
            return settimane;
        }
    }
}
