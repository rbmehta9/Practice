using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = F1(1);
            Thread.Sleep(1000);

            var t2 = F1(2);
            Thread.Sleep(1000);

            var t3 = F1(3);
            Thread.Sleep(1000);

            Task.WhenAll(t1, t2, t3).ContinueWith((result) => { Console.WriteLine("\nPress any key to exit......"); });

            Console.ReadKey();
        }

        private static async Task<int> F1(int step)
        {
            await F2(step, 1);
            await F2(step, 2);
            await F2(step, 3);
            return 0;
        }

        private static async Task<int> F2(int step, int subStep)
        {
            int delay = 0;
            if (step == 1)
                delay = 8;
            else if (step == 2)
                delay = 4;
            else if (step == 3)
                delay = 2;

            Console.WriteLine($"Call {step}-{subStep} Start, Delay = {delay} seconds\n");
            await Task.Delay(1000 * delay);
            Console.WriteLine($"Call {step}-{subStep} End\n");
            return 1;
        }
    }
}
