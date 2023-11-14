using System;

class Werknemer
{
    public string? naamWerknemer { get; set; }
    public int? jarenInVerkoop { get; set; }
    public int? jarenInOndersteuning { get; set; }
    public int? jarenInAdministratie { get; set; }


}

class Program
{
    static void Main(string[] args)
    {
        Werknemer w1 = new Werknemer();

        Console.Write("Naam werknemer: ");
        w1.naamWerknemer = Console.ReadLine();

        Console.WriteLine($"Heeft {w1.naamWerknemer} voor afdeling Verkoop gewerkt? (y/n)");
        if (Console.ReadLine() == "y")
        {
            Console.WriteLine("Geef de dienstjaren voor afdeling Verkoop");
            w1.jarenInVerkoop = geefJaren();
        }

        Console.WriteLine($"Heeft {w1.naamWerknemer} voor afdeling Ondersteuning gewerkt? (y/n)");
        if (Console.ReadLine() == "y")
        {
            Console.WriteLine("Geef de dienstjaren voor afdeling Ondersteuning");
            w1.jarenInOndersteuning = geefJaren();
        }

        Console.WriteLine($"Heeft {w1.naamWerknemer} voor afdeling Administratie gewerkt? (y/n)");
        if (Console.ReadLine() == "y")
        {
            Console.WriteLine("Geef de dienstjaren voor afdeling Administratie");
            w1.jarenInAdministratie = geefJaren();
        }

        double bonusPercentage = berekenBonusPercentage(w1.jarenInVerkoop, w1.jarenInOndersteuning, w1.jarenInAdministratie);

        Console.WriteLine($"Bonuspercentage voor {w1.naamWerknemer}: {bonusPercentage}");

        Console.ReadLine();
    }

    static int geefJaren()
    {
        int years;
        while (!int.TryParse(Console.ReadLine(), out years) || years < 0)
        {
            Console.Write("Geef een geldig nummer aub.");
        }
        return years;

    }

    static double berekenBonusPercentage(int? jarenInVerkoop, int? jarenInOndersteuning, int? jarenInAdministratie)
    {
        int aantalAfdelingenVoorGewerkt = 0;

        if (jarenInVerkoop > 0)
        {
            aantalAfdelingenVoorGewerkt++;
        }

        if (jarenInOndersteuning > 0)
        {
            aantalAfdelingenVoorGewerkt++;
        }

        if (jarenInAdministratie > 0)
        {
            aantalAfdelingenVoorGewerkt++;
        }

        if (aantalAfdelingenVoorGewerkt > 1)
        {
            return (jarenInVerkoop.GetValueOrDefault() + jarenInOndersteuning.GetValueOrDefault() + jarenInAdministratie.GetValueOrDefault()) * 2;
        }

        return 0;
    }
}