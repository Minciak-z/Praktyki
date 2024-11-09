using System;
using System.Collections.Generic;
using System.Linq;


namespace Koszyk
{
    class Produkt
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public Produkt(int id, string nazwa, decimal cena)
        {
            ID = id;
            Nazwa = nazwa;
            Cena = cena;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Produkt> produkty = new List<Produkt>
            {
                new Produkt(1, "Mleko", 5.50m),
                new Produkt(2, "Pomarańcza", 2.30m),
                new Produkt(3, "Kiełbasa", 10.00m),
                new Produkt(4, "Szczypiorek", 4.00m),
                new Produkt(5, "Chleb", 3.50m),
                new Produkt(6, "Szynka", 2.00m)
            };

            Console.WriteLine("Produkty w bazie danych:");
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"ID: {produkt.ID}, Nazwa: {produkt.Nazwa}, Cena: {produkt.Cena:C}");
            }
        }
    }
}
