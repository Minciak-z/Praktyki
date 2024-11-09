using System;

namespace RPG
{
    public interface IPostac
    {
        string Imie { get; set; }
        string Klasa { get; set; }
        int Sila { get; set; }
        int Zrecznosc { get; set; }
        int Inteligencja { get; set; }
        int HP { get; set; }
        int Mana { get; set; }
        int Szczescie { get; set; }

        void Wyswietlenie();
        void Atak(ISkill skill, IPostac target);
    }

    public interface ISkill
    {
        void Uzyj(IPostac target);
    }

    public class Postac : IPostac
    {
        public string Imie { get; set; }
        public string Klasa { get; set; }
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Inteligencja { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Szczescie { get; set; }

        public Postac(string imie, string klasa, int sila, int zrecznosc, int inteligencja, int hp, int mana, int szczescie)
        {
            Imie = imie;
            Klasa = klasa;
            Sila = sila;
            Zrecznosc = zrecznosc;
            Inteligencja = inteligencja;
            HP = hp;
            Mana = mana;
            Szczescie = szczescie;
        }

        public void Wyswietlenie()
        {
            Console.WriteLine($"Imię: {Imie}");
            Console.WriteLine($"Klasa: {Klasa}");
            Console.WriteLine($"Siła: {Sila}");
            Console.WriteLine($"Zręczność: {Zrecznosc}");
            Console.WriteLine($"Inteligencja: {Inteligencja}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Szczęście: {Szczescie}");
        }

        public void Atak(ISkill skill, IPostac target)
        {
            skill.Uzyj(target);
        }
    }

    public class Wróg : Postac
    {
        public Wróg(string imie, string klasa, int sila, int zrecznosc, int inteligencja, int hp, int mana, int szczescie)
            : base(imie, klasa, sila, zrecznosc, inteligencja, hp, mana, szczescie)
        {
        }
    }

    public class AttackSkill : ISkill
    {
        public void Uzyj(IPostac target)
        {
            target.HP -= 50; 
            Console.WriteLine($"{target.Imie} został zaatakowany, -50 HP!");
        }
    }

    class Gra
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zaprojektuj swoja postac:");
            Console.Write("Imię: ");
            string imie = Console.ReadLine();

            Console.WriteLine("Wybierz klasę z poniższej listy:");
            Console.WriteLine("1. Wojownik");
            Console.WriteLine("2. Mag");
            Console.WriteLine("3. Łucznik");
            Console.WriteLine("4. Złodziej");

            int wyborKlasy;
            string klasa = string.Empty;

            do
            {
                Console.Write("Wybierz numer klasy (1-4): ");
                wyborKlasy = int.Parse(Console.ReadLine());

                switch (wyborKlasy)
                {
                    case 1:
                        klasa = "Wojownik";
                        break;
                    case 2:
                        klasa = "Mag";
                        break;
                    case 3:
                        klasa = "Łucznik";
                        break;
                    case 4:
                        klasa = "Z łodziej";
                        break;
                    default:
                        Console.WriteLine("Klasa nie istnieje, podaj inny numer");
                        break;
                }
            } while (string.IsNullOrEmpty(klasa));

            Console.Write("Siła: ");
            int sila = int.Parse(Console.ReadLine());
            Console.Write("Zręczność: ");
            int zrecznosc = int.Parse(Console.ReadLine());
            Console.Write("Inteligencja: ");
            int inteligencja = int.Parse(Console.ReadLine());
            Console.Write("HP: ");
            int hp = int.Parse(Console.ReadLine());
            Console.Write("Mana: ");
            int mana = int.Parse(Console.ReadLine());
            Console.Write("Szczęście: ");
            int szczescie = int.Parse(Console.ReadLine());

            IPostac postac = new Postac(imie, klasa, sila, zrecznosc, inteligencja, hp, mana, szczescie);
            Console.WriteLine("\nTwoja postać:");
            postac.Wyswietlenie();

            Console.WriteLine("\nTwój pierwszy przeciwnik:");
            Wróg smok = new Wróg("Smok", "Wróg", 300, 5, 2, 200, 0, 0);
            smok.Wyswietlenie();

            ISkill attack = new AttackSkill();

            Console.WriteLine("\nPostać atakuje wroga:");
            postac.Atak(attack, smok);
            Console.WriteLine($"HP wroga po ataku: {smok.HP}\n");

            Console.WriteLine("Wróg atakuje postać:");
            smok.Atak(attack, postac);
            Console.WriteLine($"HP postaci po ataku: {postac.HP}\n");
        }
    }
}