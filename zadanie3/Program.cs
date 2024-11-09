using System;

namespace SystemBankowy
{
    public class Konto
    {
        String Wlasciciel { get; set; }
        decimal Teraz { get; set; }

        public Konto(string wlasciciel)
        {
            Wlasciciel = wlasciciel;
            Teraz = 0;
        }

        public void Wplacanie(decimal kwota)
        {
            if (kwota < 0)
            {
                Console.WriteLine("Kwota musi byc wieksza od zera");
                return;
            }

            Teraz += kwota;
            Console.WriteLine("Na konto wplacono" + kwota + " Nowyb stan konta: " + Teraz);
        }

        public void Wyplacanie(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota musi byc wieksza od zera");
                return;
            }
            if (kwota > Teraz)
            {
                Console.WriteLine("Niemoza wyplacic: za malo pieniedzy na koncie");
                return;
            }

            Teraz -= kwota;
            Console.WriteLine("Z konta wyplacono: " + kwota + " Nowy stan konta: " + Teraz);

        }
        public void Lokata()
        {
            decimal odsetki = Teraz * 0.05m;
            Teraz += odsetki;
            Console.WriteLine("Do konta z odsetek dodano: " + odsetki + " Stan konta po dodaniu to " + Teraz);
        }

        class Bank
        {
            static void Main(string[] args)
            {
                Konto konto = new Konto("Nikola Nowak");

                konto.Wyplacanie(40);
                konto.Wplacanie(10);
                konto.Wyplacanie(100);

                konto.Lokata();
                Console.WriteLine("Koncowy stan konta: " + konto.Wlasciciel + " wynosi: " + konto.Teraz);

            }
        }
    }
}