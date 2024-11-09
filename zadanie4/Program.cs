using System;

class KontoBankowe
{
    public string Wlasciciel { get;  set; }
    public decimal Teraz { get;  set; }
    public KontoBankowe(string wlasciciel)
    {
        Wlasciciel = wlasciciel;
        Teraz = 0;
    }
    public void Wplac(decimal kwota)
    {
        if (kwota > 0)
        {
            Teraz += kwota;
            Console.WriteLine($"Na konto wplacono: {kwota}. Twoj stan konta to : {Teraz}");
        }
        else
        {
            Console.WriteLine("Kwota musi być większa od zera.");
        }
    }
    public void Wyplac(decimal kwota)
    {
        if (kwota > 0 && kwota <= Teraz)
        {
            Teraz -= kwota;
            Console.WriteLine($"Z konta wyplacono: {kwota}. Twoj stan konta to: {Teraz}");
        }
        else
        {
            Console.WriteLine("Nie można wypłacić tej kwoty.");
        }
    }
    public void Sprawdz()
    {
        Console.WriteLine($"Twoj aktualny stan konta to: {Teraz}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        KontoBankowe konto = new KontoBankowe("Nikola Nowak");
        bool kontynuuj = true;

        while (kontynuuj)
        {
            Console.WriteLine("\nWybierz operację:");
            Console.WriteLine("1. Wpłata");
            Console.WriteLine("2. Wypłata");
            Console.WriteLine("3. Sprawdź stan konta");
            Console.WriteLine("4. Zakończ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj kwotę do wpłaty: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal kwotaWplaty))
                    {
                        konto.Wplac(kwotaWplaty);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa kwota.");
                    }
                    break;

                case "2":
                    Console.Write("Podaj kwotę do wypłaty: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal kwotaWyplaty))
                    {
                        konto.Wyplac(kwotaWyplaty);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa kwota.");
                    }
                    break;

                case "3":
                    konto.Sprawdz();
                    break;

                case "4":
                    kontynuuj = false;
                    Console.WriteLine("Zamknieto aplikacje");
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
    }
}