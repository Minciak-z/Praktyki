﻿using System;

namespace RPG
{
    public interface IPostac
    {
        void WyswietlInformacje();
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
        public int Szczęście { get; set; }

        public Postac(string imie, string klasa, int sila, int zrecznosc, int inteligencja, int hp, int mana, int szczescie)
        {
            Imie = imie;
            Klasa = klasa;
            Sila = sila;
            Zrecznosc = zrecznosc;
            Inteligencja = inteligencja;
            HP = hp;
            Mana = mana;
            Szczęście = szczescie;
        }

        public virtual void WyswietlInformacje()
        {
            Console.WriteLine($"Imię: {Imie}");
            Console.WriteLine($"Klasa: {Klasa}");
            Console.WriteLine($"Siła: {Sila}");
            Console.WriteLine($"Zręczność: {Zrecznosc}");
            Console.WriteLine($"Inteligencja: {Inteligencja}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Szczęście: {Szczęście}");
        }
    }

    public abstract class DekoratorPostaci : IPostac
    {
        protected IPostac _postac;

        public DekoratorPostaci(IPostac postac)
        {
            _postac = postac;
        }

        public virtual void WyswietlInformacje()
        {
            _postac.WyswietlInformacje();
        }
    }

    public class Wróg : IPostac
    {
        public string Imie { get; set; }
        public string Klasa { get; set; }
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Inteligencja { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Szczęście { get; set; }

        public Wróg(string imie, string klasa, int sila, int zrecznosc, int inteligencja, int hp, int mana, int szczescie)
        {
            Imie = imie;
            Klasa = klasa;
            Sila = sila;
            Zrecznosc = zrecznosc;
            Inteligencja = inteligencja;
            HP = hp;
            Mana = mana;
            Szczęście = szczescie;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Imię wroga: {Imie}");
            Console.WriteLine($"Klasa: {Klasa}");
            Console.WriteLine($"Siła: {Sila}");
            Console.WriteLine($"Zręczność: {Zrecznosc}");
            Console.WriteLine($"Inteligencja: {Inteligencja}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Szczęście: {Szczęście}");
        }
    }

    class Gra
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadź szczegóły postaci:");
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
                        klasa = "Złodziej";
                        break;
                    default:
                        Console.WriteLine("Klasa nie istnieje podaj inny numer");
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
            postac.WyswietlInformacje();

            Console.WriteLine("\n Twoj pierwszy przeciwnik:");
            Wróg Smok = new Wróg("Smok", "Wróg", 300, 5, 2, 200, 0, 0);
            Smok.WyswietlInformacje();
        }
    }
}