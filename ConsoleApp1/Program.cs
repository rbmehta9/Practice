using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i <= 2; i++)
            {

                new ConsoleApp1.Program().PrintDifferentMessages(i);
            }

            //new ConsoleApp1.Program().PrintDifferentMessages();

            Console.ReadLine();
        }

        public void PrintDifferentMessages(int i)
        {
            Console.WriteLine("Adit Ties his shoe" + i);
            Console.WriteLine("Adit wears his jacket" + i);
            Console.WriteLine("Adit takes his bag" + i);
            Console.WriteLine("Adit gets into our car" + i);
            Console.WriteLine("Adit reaches clubhouse" + i);
        }
    }
}
