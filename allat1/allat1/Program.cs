using System;
using System.Collections.Generic;

public class Allat
{
    private string nev;
    private int szuletesiEv;
    private int szepsegPont;
    private int viselkedesPont;
    private int pontSzam;

    public static int AktualisEv { get; set; }
    public static int KorHatar { get; set; }

    public Allat(string nev, int szuletesiEv)
    {
        this.nev = nev;
        this.szuletesiEv = szuletesiEv;
    }

    public int Kor()
    {
        return AktualisEv - szuletesiEv;
    }

    public void Pontozzak(int szepsegPont, int viselkedesPont)
    {
        this.szepsegPont = szepsegPont;
        this.viselkedesPont = viselkedesPont;
        if (Kor() <= KorHatar)
        {
            pontSzam = viselkedesPont * Kor() + szepsegPont * (KorHatar - Kor());
        }
        else
        {
            pontSzam = 0;
        }
    }

    public override string ToString()
    {
        return nev + " pontszáma: " + pontSzam + " pont";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Az aktuális év és a korhatár beállítása
            Allat.AktualisEv = 2023;
            Allat.KorHatar = 10;

            List<Allat> allatok = new List<Allat>();
            Random random = new Random();
            string nev;
            int szuletesiEv;

            while (true)
            {
                Console.Write("Adja meg az állat nevét (vagy nyomjon Entert a befejezéshez): ");
                nev = Console.ReadLine();
                if (string.IsNullOrEmpty(nev)) break;

                Console.Write("Adja meg az állat születési évét: ");
                szuletesiEv = int.Parse(Console.ReadLine());

                Allat allat = new Allat(nev, szuletesiEv);

                int szepseg = random.Next(1, 11); // 1-től 10-ig véletlen pontszám
                int viselkedes = random.Next(1, 11); // 1-től 10-ig véletlen pontszám

                allat.Pontozzak(szepseg, viselkedes);
                allatok.Add(allat);

                Console.WriteLine(allat);
            }

            // Statisztikák kiíratása
            if (allatok.Count > 0)
            {
                int osszPontszam = 0;
                int maxPontszam = 0;

                foreach (var allat in allatok)
                {
                    osszPontszam += allat.Pontszam;
                    if (allat.Pontszam > maxPontszam)
                    {
                        maxPontszam = allat.Pontszam;
                    }
                }

                double atlagPontszam = (double)osszPontszam / allatok.Count;

                Console.WriteLine($"Összesen {allatok.Count} állat versenyzett.");
                Console.WriteLine($"Átlagos pontszámuk: {atlagPontszam:F2}");
                Console.WriteLine($"Legmagasabb pontszám: {maxPontszam}");
            }
            else
            {
                Console.WriteLine("Nem volt versenyző állat.");
            }

            Console.ReadKey();
        }
    }
}
