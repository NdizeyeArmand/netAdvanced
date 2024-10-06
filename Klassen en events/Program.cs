using System;

public delegate void BestellingBevestigdEventHandler(object sender, EventArgs e);
public enum Verschijningsperiode
{
    Dagelijks, Wekelijks, Maandelijks
}

class Boek
{
    private string Isbn;
    private string Naam;
    private string Uitgever;
    private double Prijs;

    public Boek(string isbn, string naam, string uitgever, double prijs)
    {
        Isbn = isbn;
        Naam = naam;
        Uitgever = uitgever;
        Prijs = prijs;
    }

    public string geefIsbn
    {
        get { return Isbn; }
        set { Isbn = value; }
    }

    public string geefNaam
    {
        get { return Naam; }
        set { Naam = value; }
    }

    public string geefUitgever
    {
        get { return Uitgever; }
        set { Uitgever = value; }
    }

    public double geefPrijs
    {
        get { return Prijs; }
        set { Prijs = Math.Max(5, Math.Min(50, value)); }
    }

    public virtual void Lees()
    {
        Console.WriteLine("Geef de boekgegevens");
        Console.WriteLine("ISBN: ");
        Isbn = Console.ReadLine();
        Console.WriteLine("Naam boek: ");
        Naam = Console.ReadLine();
        Console.WriteLine("Uitgever boek: ");
        Uitgever = Console.ReadLine();
        Console.WriteLine("Prijs boek: ");
        Prijs = Convert.ToDouble(Console.ReadLine());
    }

    public override string? ToString()
    {
        return $"Tijdschrift: ISBN {Isbn}, Naam: {Naam}, Uitgever: {Uitgever}, Prijs: € {Prijs}";
    }
}

class Tijdschrift : Boek
{
    public Verschijningsperiode v { get; set; }
    public Tijdschrift(string isbn, string naam, string uitgever, double prijs, Verschijningsperiode v) : base(isbn, naam, uitgever, prijs)
    {
        v = v;
    }

    public override void Lees()
    {
        Console.WriteLine("Geef de boekgegevens");
        Console.WriteLine("ISBN: ");
        geefIsbn = Console.ReadLine();
        Console.WriteLine("Naam boek: ");
        geefNaam = Console.ReadLine();
        Console.WriteLine("Uitgever boek: ");
        geefUitgever = Console.ReadLine();
        Console.WriteLine("Prijs boek: ");
        geefPrijs = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Kies verschijningsperiode boek: ");
        Console.WriteLine("0: Dagelijks");
        Console.WriteLine("1: Wekelijks");
        Console.WriteLine("2: Maandelijks");
        Console.Write("Uw keuze: ");
        int keuze = Convert.ToInt16(Console.ReadLine());

        switch (keuze)
        {
            case 0:
                v = Verschijningsperiode.Dagelijks;
                break;
            case 1:
                v = Verschijningsperiode.Wekelijks;
                break;
            case 2:
                v = Verschijningsperiode.Maandelijks;
                break;
            default:
                Console.WriteLine("Foute invoer. Default is Dagelijks.");
                v = Verschijningsperiode.Dagelijks;
                break;
        }
    }

    public override string? ToString()
    {
        return $"Tijdschrift: ISBN {geefIsbn}, Naam: {geefNaam}, Uitgever: {geefUitgever}, Prijs: € {geefPrijs}, Verschijningsperiode: {v}";
    }
}

class Bestelling<T>
{
    private static int volgnummer = 1;
    private int _id;
    public int Id { 
        get { return _id; }
        private set { _id = value; } 
    }
    public T Item { get; }
    public DateTime Datum { get; }
    public int Aantal { get; }
    public Verschijningsperiode? v { get; }

    public event BestellingBevestigdEventHandler BestellingBevestigd;

    public Bestelling(T item, int aantal, Verschijningsperiode? v = null)
    {
        Id = volgnummer++;
        Item = item;
        Aantal = aantal;
        this.v = v;
    }

    public Tuple<string, int, double> Bestel()
    {
        string Isbn = "";
        double totaalPrijs = 0;

        if (Item is Boek) {
            totaalPrijs = (Item as Boek).geefPrijs * Aantal;
            Isbn = (Item as Boek).geefIsbn;

            OnKlaar();
        } else if (Item is Tijdschrift) {
            totaalPrijs = (Item as Tijdschrift).geefPrijs * Aantal;
            Isbn = (Item as Tijdschrift).geefIsbn;
        }

        return new Tuple<string, int, double>(Isbn, Aantal, totaalPrijs);
    }

    protected virtual void OnKlaar()
    {
        BestellingBevestigd?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    private static void BoekBestelling_BestellingBevestigd(object sender, EventArgs e)
    {
        Console.WriteLine("Bestelling bevestigd!");
    }

    static void Main(string[] args)
    {

        Boek b1 = new Boek("9789000381609", "Elon Musk", "Standaard Uitgeverij", 40.0);
        Boek b2 = new Boek("9789000348640", "Steve Jobs", "Standaard Uitgeverij", 20.0);

        Tijdschrift t1 = new Tijdschrift("589930", "Ronaldo", "Uitgeverij Voetbal", 16.0, Verschijningsperiode.Maandelijks);
        Tijdschrift t2 = new Tijdschrift("432907", "Actua", "De Morgen", 10.0, Verschijningsperiode.Wekelijks);

        Bestelling<Boek> boekBestelling = new Bestelling<Boek>(b1, 13);
        Bestelling<Tijdschrift> tijdschriftBestelling = new Bestelling<Tijdschrift>(t1, 7);

        boekBestelling.BestellingBevestigd += BoekBestelling_BestellingBevestigd;
        tijdschriftBestelling.BestellingBevestigd += BoekBestelling_BestellingBevestigd;

        Console.WriteLine(boekBestelling.Bestel());
        Console.WriteLine(tijdschriftBestelling.Bestel());
    }
}
