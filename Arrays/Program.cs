using System;

class Program
{

    static void Main(string[] args)
    {
        int[] lijst  = new int[4];
        fillArray(lijst);

        Console.WriteLine("items lijst:");
        PrintList(lijst);

        // lijst[4] = 99;
        lijst = TryAddElement(lijst, 99);
        lijst = TryAddElement(lijst, 100);
        lijst = TryAddElement(lijst, 101);

        Console.WriteLine("items lijst geüpdated");
        PrintList(lijst);



        Console.ReadLine();

    }

    static void fillArray(int[] lijst)
    {
        lijst[0] = 1;
        lijst[1] = 2;
        lijst[2] = 3;
        lijst[3] = 4;
    }

    static int[] TryAddElement(int[] lijst, int value)
    {
        if (lijst.Length < 5)
        {
            int[] newArray = new int[lijst.Length + 1];

            for (int i = 0; i < lijst.Length; i++)
            {
                newArray[i] = lijst[i];
            }

            newArray[lijst.Length] = value;

            return newArray;
        }
        else
        {
            lijst[lijst.Length - 1] = value;
            return lijst;
        }
    }

        static void PrintList(int[] lijst)
    {
        foreach (var item in lijst)
        {
            Console.WriteLine(item);
        }
    }
}