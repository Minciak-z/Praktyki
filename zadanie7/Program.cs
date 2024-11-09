using System;
using System.Collections.Generic;
using System.Linq;

namespace BazaDanych
{
    class Produkt
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public decimal cena { get; set; }
        public string kategoria { get; set; }
        public string SortowanieKategoria { get; internal set; }

        public Produkt(int iD, string nazwa, decimal cena, string kategoria)
        {
            ID = iD;
            this.nazwa = nazwa;
            this.cena = cena;
            this.kategoria = kategoria;
        }
    }
    class Koszyk
    {
        public List<Produkt> produkty = new List<Produkt>();

        public void DodajProdukt(Produkt produkt)
        {
            produkty.Add(produkt);
        }

        public void PokazKoszyk()
        {
            Console.WriteLine("\nW Twoim koszyku znajdują się:");
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"  {produkt.nazwa}, Cena: {produkt.cena:C}");
            }
        }

        public void Zapytanie1()
        {
            var posortowaneProdukty = produkty.OrderByDescending(p => p.cena).ToList();
            Console.WriteLine("\n Produkty posortowane od najwyzszej do najnizszej ceny: ");
            foreach (var produkt in posortowaneProdukty)
            {
                Console.WriteLine($"ID: {produkt.ID}, Nazwa: {produkt.nazwa}, Cena: {produkt.cena} ");
            }
        }

        public void Zapytanie2(string kategoria)
        {
            var posortowaneKategorie = produkty.Where(p => p.kategoria == kategoria).ToList();
            Console.WriteLine($"\n Produkty o kategori: {kategoria}");
            foreach ( var produkt in posortowaneKategorie)
            {
                Console.WriteLine($"ID: {produkt.ID}, Nazwa: {produkt.nazwa}, Cena: {produkt.cena}, Kategoria: {produkt.kategoria}");
            }
        }

       
    }

    class Baza
    {
        static void Main(string[] args)
        {
            List<Produkt> produkty = new List<Produkt>
            {
                new Produkt(1, "Mleko", 5.50m,"Nabial"),
                new Produkt(2, "Pomarancza", 2.30m,"Owoc"),
                new Produkt(3, "Kielbasa", 10.00m,"Mieso"),
                new Produkt(4, "Szczypiorek", 4.00m,"Warzywo"),
                new Produkt(5, "Chleb", 3.50m,"Pieczywo"),
                new Produkt(6, "Szynka", 2m,"Mieso")
            };

            Koszyk koszyk = new Koszyk();

            foreach (var produkt in produkty)
            {
                koszyk.DodajProdukt(produkt);
            }

            koszyk.PokazKoszyk();

            koszyk.Zapytanie1();

            koszyk.Zapytanie2("Nabial");

            
        }
    }
}