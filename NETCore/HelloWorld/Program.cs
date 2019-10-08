using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name} {new HelloWorldClasses.Class1().GetValue()}, on {date:d} at {date:t}!");
            Console.Write("\nPress any key to exit1111111...");
            Console.ReadKey(true);
        }
    }
}
