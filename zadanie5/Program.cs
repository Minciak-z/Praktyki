using System;

namespace HelloWorld
{
    class Produkt
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public decimal cena { get; set; }

        public Produkt(int iD, string nazwa, decimal cena)
        {
            ID = iD;
            this.nazwa = nazwa;
            this.cena = cena;
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
            Console.WriteLine("\n w twoim koszyku znajduja sie: ");
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"ID"+ produkt.ID + " ,Nazwa: "+ produkt.nazwa+ ",Cena: " + produkt.cena);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Koszyk koszyk = new Koszyk();

            koszyk.DodajProdukt(new Produkt(1, "Mleko", 5.50m));
            koszyk.DodajProdukt(new Produkt(2, "Pomarancza", 2.30m));
            koszyk.DodajProdukt(new Produkt(3, "Kielbasa", 10m));
            koszyk.DodajProdukt(new Produkt(4, "sczypiorek", 4m));

            koszyk.PokazKoszyk();
        }
    }
}