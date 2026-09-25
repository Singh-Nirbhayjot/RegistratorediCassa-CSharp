using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RegistratorediCassa_C_
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CCliente> clienti = new List<CCliente>();
            CRegistratore registratore = new CRegistratore();

            bool tessera;
            Console.WriteLine("Il cliente ha tessera fedeltà? Si o No");
            if (Console.ReadLine().ToLower() == "si")
                tessera = true;
            else 
                tessera = false;


            CCliente cliente = new CCliente(tessera);
            clienti.Add(cliente);

            Console.WriteLine("Inserisci 3 articoli alimentari");
            for(int i = 0; i< 3; i++)
            {
                bool corretto = false;
                while (!corretto)
                {
                    try
                    {
                        Console.WriteLine("Codice a barre:");
                        long codiceBarre;
                        long.TryParse(Console.ReadLine(), out codiceBarre);

                        Console.WriteLine("Descrizione:");
                        string descrizione = Console.ReadLine();

                        Console.WriteLine("Prezzo:");
                        float prezzo;
                        float.TryParse(Console.ReadLine(), out prezzo);

                        Console.WriteLine("Anno di scadenza:");
                        int annoScadenza;
                        int.TryParse(Console.ReadLine(), out annoScadenza);

                        CArticolo articolo = new CArticoloAlimentare(codiceBarre, descrizione, prezzo, annoScadenza);
                        cliente.SalvaAcquisti(articolo);

                        corretto = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore: " + ex.Message);
                        Console.WriteLine("Inserisci nuovamente l'articolo");
                    }
                }
            }
            Console.WriteLine("Inserisci 2 articoli non alimentari");
            for (int i = 0; i < 2; i++)
            {
                bool corretto = false;
                while (!corretto)
                {
                    try
                    {
                        Console.WriteLine("Codice a barre:");
                        long codiceBarre;
                        long.TryParse(Console.ReadLine(), out codiceBarre);

                        Console.WriteLine("Descrizione:");
                        string descrizione = Console.ReadLine();

                        Console.WriteLine("Prezzo:");
                        float prezzo;
                        float.TryParse(Console.ReadLine(), out prezzo);

                        Console.WriteLine("Inserisci materiale:");
                        string materiale = Console.ReadLine();

                        CArticolo articolo = new CArticoloNonAlimentare(codiceBarre, descrizione, prezzo, materiale);
                        cliente.SalvaAcquisti(articolo);
                        corretto = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore: " + ex.Message);
                        Console.WriteLine("Inserisci nuovamente l'articolo");
                    }
                }
            }

            Console.WriteLine("--Scontrino--");
            float tot = 0;
            foreach(CArticolo articolo in cliente.VediStorico())
            {
                float prezzoFinale;
                if (cliente.TesseraFedelta)
                    prezzoFinale = articolo.Sconta();

                else
                    prezzoFinale = articolo.Prezzo;
                Console.WriteLine(articolo.Descrizione + prezzoFinale.ToString()+ "€");

                tot += prezzoFinale;
            }
            Console.WriteLine("Totale: " + tot + "€");
            registratore.EmettiScontrino((int)tot);


            List<CScontrino> lista = registratore.ListaScontrini();
            foreach (CScontrino s in lista)
            {
                Console.WriteLine("Scontrino n. " + s.Id + "- Importo: " + s.Importo + "€");
            }

            Console.WriteLine("Ricerca clienti per prodotto");
            Console.WriteLine("Inserisci codice barre");
            long codRicerca;
            long.TryParse(Console.ReadLine(), out codRicerca);

            foreach(CCliente c in clienti)
            {
                foreach(CArticolo articolo in c.VediStorico())
                {
                    if(articolo.CodiceBarre == codRicerca)
                    {
                        Console.WriteLine("Il cliente ha acquistato il prodotto");
                    }
                }
            }

            Console.WriteLine("Inserisci il mese da visualizzare:");
            int mese = int.Parse(Console.ReadLine());

            List<CScontrino> listaMese = registratore.ListaPerMese(mese);

            foreach (CScontrino s in listaMese)
            {
                Console.WriteLine("Scontrino n. " + s.Id + "- Importo: " + s.Importo + "€");
            }

            Console.WriteLine("Inserisci la settimana da visualizzare:");
            int settimana = int.Parse(Console.ReadLine());

            List<CScontrino> listaSettimana = registratore.ListaPerSettimana(settimana);

            foreach (CScontrino s in listaSettimana)
            {
                Console.WriteLine("Scontrino n. " + s.Id + "- Importo: " + s.Importo + "€");
            }
        }

    }
}
