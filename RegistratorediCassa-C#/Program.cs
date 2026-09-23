using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RegistratorediCassa_C_
{
    public enum Materiale
    {
        Vetro,
        Carta,
        Plastica
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CCliente> clienti = new List<CCliente>();

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
                }catch(Exception ex)
                {
                    Console.WriteLine("Errore: "+ ex.Message);
                }
            }
            Console.WriteLine("Inserisci 2 articoli non alimentari");
            for (int i = 0; i < 2; i++)
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

                    Console.WriteLine("Materiale:");
                    Console.WriteLine("0 - Vetro");
                    Console.WriteLine("1 - Carta");
                    Console.WriteLine("2 - Plastica");

                    int scelta = int.Parse(Console.ReadLine());
                    if (scelta < 0 || scelta > 2)
                        throw new Exception("Materiale non valido");


                    Materiale materiale = (Materiale)scelta;
                    CArticolo articolo = new CArticoloNonAlimentare(codiceBarre, descrizione, prezzo, materiale);
                    cliente.SalvaAcquisti(articolo);
                }catch(Exception ex)
                {
                    Console.WriteLine("Errore: "+ ex.Message);
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
        }

    }
}
