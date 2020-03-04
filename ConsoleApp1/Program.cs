using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class A
    {
        public int Id { get; set; }

        public int PId { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //for (var i = 1; i <= 2; i++)
            //{

            //    new ConsoleApp1.Program().PrintDifferentMessages(i);
            //}

            //var dictionary = new Dictionary<int, int>();
            //dictionary.Add(0, 1);


            //var array = new int[4] {2, 7, 11, 15};
            //var result = new ConsoleApp1.Program().TwoSum(array, 9);

            var lst = new List<A>()
            {
                new A() {Id = 1, PId = 1, Name = "a1"},
                new A() {Id = 2, PId = 1, Name = "a2"},
                new A() {Id = 3, PId = 1, Name = "a3"},
                new A() {Id = 4, PId = 2, Name = "a4"},
                new A() {Id = 5, PId = 2, Name = "a5"}
            };

            var grp = lst.GroupBy(l => l.PId);

            foreach (var grpch in grp)
            {
                var a = grpch.ToList();
            }

            //var a = new List<int>();
            //var b = a.Select(a1 => a1);

            //var a = new Program().GetStudentInfo1((default(string), default(int)));
            //var b = new Program().GetStudentInfo2(null);
            //A a = null;
            //new Program().TestMethod(a);


            Console.ReadLine();
        }

        public void TestMethod(A a)
        {
            a = new A();
        }

        public (string name, int age) GetStudentInfo(string id)
        {
            // Search by ID and find the student.
            return (name: "Annie", age: 25);
        }

        public (string name, int age) GetStudentInfo1( (string name, int age) tuple)
        {
            // Search by ID and find the student.
            return (name: "Annie", age: 25);
        }

        public (string name, int age) GetStudentInfo2(Tuple<string, int> tuple)
        {
            // Search by ID and find the student.
            return (name: "Annie", age: 25);
        }

        public void Test()
        {
            (string name, int age) info = GetStudentInfo("100-000-1000");
            Console.WriteLine($"Name: {info.name}, Age: {info.age}");
        }

        public int[] TwoSum(int[] arr, int target)
        {
            var dictionary = new Dictionary<int, int>();
            var i = 0;
            while (i < arr.Length)
            {
                if (dictionary.ContainsKey(arr[i]))
                    return new int[2] { dictionary[arr[i]], i };

                if (target > arr[i])
                    dictionary.Add(target - arr[i], i);

                i++;
            }

            return new int[2] { -1, -1 };
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
