using System;
namespace factorial

{
    class Program
    {

        static int factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * factorial(n - 1);

        }

        static void Main(string[] args)
        {

            // Doe begroeting
            Console.WriteLine("**********");
            Console.WriteLine("Bereken de faculteit van een getal");
            Console.WriteLine("**********");
            Console.WriteLine();
            Console.WriteLine("Van welk getal moet de faculteit berekend worden?");

            int getal = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Met welke type iteratie moet de berekening gebeuren?");
            Console.WriteLine("1. For-Loop");
            Console.WriteLine("2. While-Loop");
            Console.WriteLine("3. Do-While-Loop");
            Console.WriteLine("4. Recursie");
            Console.WriteLine("Geef jouw keuze: ");
            char keuze = Console.ReadLine().First();

            long nFaculteit = 1;
            int i = 1;

            switch (keuze)
            {
                case '1':
                    // Gebruik een for-loop

                    for (int teller = 1; teller <= getal; teller++)
                    {
                        if (getal <= 1)
                        {
                            break;
                        }
                        nFaculteit *= teller;

                    }
                    break;
                case '2':
                    // Gebruik een while-loop

                    while (i <= getal)
                    {
                        nFaculteit *= i;
                        i++;

                    }
                    break;
                case '3':
                    // Gebruik een do-while-loop

                    do
                    {
                        nFaculteit *= i;
                        i++;

                    } while (i <= getal);
                    break;
                case '4':
                    // Gebruik recursie

                    nFaculteit = factorial(getal);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine(getal + "! = " + nFaculteit);
            Console.WriteLine();
        }
    }
}
