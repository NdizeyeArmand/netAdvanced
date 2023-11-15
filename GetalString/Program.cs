using System;
using System.Text.RegularExpressions;

public class GetalString
{
    private string _getal;

    public string Getal
    {
        get { return _getal; }
        set { _getal = VerwijderNietGetalChars(value); }
    }

    private string VerwijderNietGetalChars(string input)
    {
        // Gebruik reguliere expressies om alleen getal-gerelateerde tekens te behouden
        string pattern = @"[-]?\d+";
        MatchCollection matches = Regex.Matches(input, pattern);

        // Voeg alle overeenkomende tekens samen tot één string
        string result = "";
        foreach (Match match in matches)
        {
            result += match.Value;
        }

        // Als er geen getal overblijft, bewaar "0"
        if (string.IsNullOrEmpty(result))
        {
            result = "0";
        }

        return result;
    }
}

class Program
{
    static void Main() 
    {
        // Test de GetalString-klasse
        GetalString testje = new GetalString();
        testje.Getal = "a-53en nog 2iets5";

        // Toon het resultaat
        Console.WriteLine(testje.Getal);  // Dit zou "-5325" moeten weergeven
    }
}
