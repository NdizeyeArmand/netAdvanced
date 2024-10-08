using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        Program p = new Program();
        API();
        Console.ReadLine();
    }

    public static async void API()
    {
        await Task.Delay(1000);
        Console.WriteLine("API called");
    }
    //static void Main()
    //{
    //    Console.WriteLine("Hello World!");
    //    Program p = new Program();
    //    p.API();
    //    Console.ReadLine();
    //}

    //public async void API()
    //{
    //    await Task.Delay(1000);
    //    Console.WriteLine("API called");
    //}
}