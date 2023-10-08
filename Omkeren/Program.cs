class Omkeren
{
    static string reverse = "";
    static int i = 1;

    static string giveReverse(string s)
    {
        if (s.Length == 0)
        {
            return "";
        }

        char last_char = s[s.Length - i];
        string substr = s.Substring(0, s.Length - i);
        reverse += last_char.ToString();

        return giveReverse(substr);
    }

    static void Main(string[] args)
    {
        char keuze, last_char;

        Console.WriteLine("Geef uw string:");
        string str = Console.ReadLine();
        Console.WriteLine("Kies de type iteratie:");
        Console.WriteLine("1. For-loop");
        Console.WriteLine("2. While-loop");
        Console.WriteLine("3. Do-While-loop");
        Console.WriteLine("4. Recursie");
        keuze = Console.ReadLine().First();

        switch (keuze)
        {
            case '1':
                for (int teller = 0; teller < str.Length; teller++)
                {
                    last_char = str[str.Length - (teller + 1)];
                    reverse += last_char.ToString();

                }
                break;
            case '2':
                while (i <= str.Length)
                {
                    last_char = str[str.Length - i];
                    reverse += last_char.ToString();
                    i++;

                }
                break;
            case '3':
                do
                {
                    last_char = str[str.Length - i];
                    reverse += last_char.ToString();
                    i++;

                } while (i <= str.Length);
                break;
            case '4':
                giveReverse(str);
                break;

        }

        Console.WriteLine("Uw string: " + reverse);
    }

}
