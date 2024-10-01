using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        API();
        Console.ReadLine();
    }

    public static async void API()
    {
        await Task.Delay(1000);
        Console.WriteLine("API called");
    }
}