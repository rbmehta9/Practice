using System;

namespace NETCoreScratch
{
    class Program
    {
        static void Main(string[] args)
        {
		    var str = "asdasd";
            var str1 = "asdasdddd";
            var cls = new StdLib.Class1();
            Console.WriteLine("Hello World!" + cls.ReturnStr() + cls.ReturnStr());
        }
    }
}
