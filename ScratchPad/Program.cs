using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace ScratchPad
{
    public enum E
    {
        A = 1,
        B = 2
    }

    public class BaseClass
    {
        public int publicId { get; set; }
        private int privateId { get; set; }
        protected int protectedId { get; set; }
        internal int internalId { get; set; }
        protected internal int protectedinternalId { get; set; }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            protectedId = 0;
        }
        public int Id { get; set; }
    }

    public class DerivedClassFromExternalAssembly : ClassLibrary1.BaseClass
    {
        public DerivedClassFromExternalAssembly()
        {
            protectedinternalId = 0;
        }
    }


    public class A
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public bool? isError { get; set; }
    }

    public class B
    {
        public string Name { get; set; }
        public string Name1 { get; set; }
    }

    public class StaticConstructorTestClass
    {
        public static int StaticProp { get; set; }
        public int NonStaticProp { get; set; }
        static StaticConstructorTestClass()
        {
            StaticProp += 9;
        }
    }

    class Program
    {
        static async void Do()
        {
           await Task.Delay(2);
        }

        public static string ReplacePath(string path1, string path2)
        {
            string sep = Path.DirectorySeparatorChar.ToString();

            var parts1 = path1.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });
            var parts2 = path2.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar });

            string compareTo = string.Empty;
            string replaceWith = string.Empty;

            for (int n2 = 0; n2 < parts2.Length; n2++)
            {
                for (int n1 = 0; n1 < parts1.Length; n1++)
                {
                    if (String.Compare(parts1[n1], parts2[n2], true) == 0)
                    {
                        compareTo = String.Join(sep, parts1, 0, n1 + 1);
                        replaceWith = String.Join(sep, parts2, 0, n2 + 1);
                    }
                }
            }

            if (!String.IsNullOrEmpty(compareTo))
            {
                return path1.Replace(compareTo, replaceWith);
            }
            else
            {
                return Path.Combine(path2, Path.GetFileName(path1));
            }
        }

        public static Dictionary<string,int> GetWordCounts(string fileName)
        {
            var dictionary = new Dictionary<string, int>();
            var word = string.Empty;
            var prevChar = '\0';
            using (var fs = new StreamReader(fileName,Encoding.UTF8))
            {
                //var txt = fs.ReadToEnd(
                while (!fs.EndOfStream)
                {
                    var ch = (char)fs.Read();
                    if (!Char.IsWhiteSpace(ch))
                        word += ch;
                    else if (!Char.IsWhiteSpace(prevChar))
                    {
                        if (!dictionary.ContainsKey(word))
                            dictionary.Add(word, 1);
                        else
                            dictionary[word] += 1;
                        word = string.Empty;
                    }

                    prevChar = ch;

                }
            }

            return dictionary;
        }

        public static void GetWordCounts1(string fileName)
        {
            var txt = string.Empty;
            var delimiters = new Char[] { ' ', ',', '.' };
            using (var fs = new StreamReader(fileName, Encoding.UTF8))
            {
                txt = fs.ReadToEnd();
            }

            var words = txt.Split(delimiters).Where(s => !string.IsNullOrWhiteSpace(s));
            var a = words.GroupBy(g => g).Select(s => new { word = s.Key, Count = s.Count() }).OrderByDescending(o => o.Count).FirstOrDefault().word;
        }

        public static int fact(int n)
        {
            if (n == 0)
                return 1;

            return n * fact(n - 1);
        }

        static void Main(string[] args)
        {
            //var str = "9X9XX99X9XX999999";
            //var str1 = "XX9X999X9XX999999";
            //var str2 = "9X99999X9XX9999XX";
            //var str3 = "9X99999X9XX99XX99";
            //var hashCode = GetHashCode(str);
            //var hashCode1 = GetHashCode(str1);
            //var hashCode2 = GetHashCode(str2);
            //var hashCode3 = GetHashCode(str3);
            //var i = 0;
            //var matched = false;
            //var result = 4;
            //while(true)
            //{
            //    var exp = 9 + i * i;
            //    if ((exp % 11) == result)
            //        break;
            //    i++;
            //}

            //int position = 0;
            //position++;
            //++position;
            //var a = 2;
            //var x = (E)a;

            //var i = 0;
            //while (i < 10)
            //    Console.WriteLine(++i % 10);

            //var array = new int?[7];
            //var a = fibonacci(array,6);
            //DoubleLoopBreak();

            //ComplexCheck(1);

            //var lstA = new List<A>()
            //{
            //    new ScratchPad.A() {Id = 1,ItemId = 100},
            //    new ScratchPad.A() {Id = 2,ItemId = 101,isError = true},
            //    new ScratchPad.A() {Id = 3,ItemId = 101},
            //    new ScratchPad.A() {Id = 4,ItemId = 101},
            //    new ScratchPad.A() {Id = 5,ItemId = 102},
            //    new ScratchPad.A() {Id = 6,ItemId = 103},
            //    new ScratchPad.A() {Id = 7,ItemId = 104},
            //    new ScratchPad.A() {Id = 8,ItemId = 105},
            //};

            //var b = HasToBeProcessed(lstA[2],lstA);
            //lstA[2].isError = false;
            //var a = lstA[2];
            //var erroredQueueRecords = lstA.Where(v => v.isError.HasValue &&
            //                                     v.isError.Value &&
            //                                     v.Id != a.Id &&
            //                                     v.ItemId == a.ItemId);

            //foreach (var record in erroredQueueRecords)
            //    record.isError = false;

            //var c = HasToBeProcessed(lstA[3], lstA);
            //for(var i =0;i<10;i++)
            //{
            //    if (i == 7)
            //        continue;
            //    Console.WriteLine($"i = {i}");
            //}

            //StaticConstructorTestClass.StaticProp = 1;
            //var a = StaticConstructorTestClass.StaticProp;
            //var obj = new StaticConstructorTestClass();

            //Console.WriteLine("Starting Main");
            //// Invoke a static method on Test
            //Test.EchoAndReturn("Echo!");
            //Console.WriteLine("After echo");
            //// Reference a static field in Test
            //string y = Test.x;
            //// Use the value just to avoid compiler cleverness
            //if (y != null)
            //{
            //    Console.WriteLine("After field access");
            //}

            //var derivedObj = new DerivedClass(3);
            //var bObj = new BaseClass();
            //var j = 0;
            //DoSomething(bObj,ref j);

            //var t1 = Tuple.Create<int,string>(0,"a");
            //var t2 = Tuple.Create<int, string>(0, "a");
            //var dict = new Dictionary<Tuple<int, string>, string>();
            //dict.Add(t1,"sdas");
            //var a = dict[t2];

            //must have a public constructor since no static property to access
            //var s1 = new SingletonNoStatic();
            //var s2 = new SingletonNoStatic();
            //try
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            var a = new A();
            //            var i = a.ItemId;
            //        }
            //        catch (Exception ex)
            //        {
            //            var b = new A();
            //            var i = b.ItemId;
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{

            //}

            //var a = ReplacePath("C:\\FtpDataRoot\\109500\\Upload\\835s_02202017_04172018.zip.PVA", "\\\\LOUQAFTP002\\FTPDataRoot");
            //var a = ReplacePath("C:\\Zirmed\\PickUp\\835s_02202017_04172018.zip.PVA", "\\\\LOUQAFTP002\\PickUp");

            //IReadOnlyDictionary<int, ABC> dict = new Dictionary<int, ABC>()
            //{
            //    {1, new ABC(){Id = 1, Name = "fadas" } },
            //    {2, new ABC(){Id = 1, Name = "fadas11" } }
            //};

            //Dictionary<string, A> points = new Dictionary<string, A>
            //{
            //    { "James", new A(){Id = 1,ItemId = 100 } },
            //    { "Jo", new A(){Id = 2,ItemId = 101 } },
            //    { "Jess", new A(){Id = 3,ItemId = 3 } }
            //};

            //var ser = new Newtonsoft.Json.JsonSerializer();
            //var ms = new MemoryStream();
            //ms.Write((byte[])points,0,0);
            //var textSer = new StreamWriter(ms);
            //ser.Serialize(textSer, points);
            //var json = JsonConvert.SerializeObject(points);
            //Console.WriteLine(json);
            //var a = JsonConvert.DeserializeObject<Dictionary<string,A>>(json);
            //int? i = null;
            //int? j = null;
            //Console.WriteLine(i == j);
            //var a = Singleton.Instance;
            //var b = Singleton.Instance;
            //var bool1 = a == b;
            //var d = GetWordCounts("C:\\Users\\ritesh.mehta\\Downloads\\abc\\abc.txt");
            //GetWordCounts1("C:\\Users\\ritesh.mehta\\Downloads\\abc\\abc.txt");
            //var a = fact(5);

            //Func<string, string> func = (s) => s.ToUpper();
            //Func<int, int, string> func1 = (n1, n2) => 
            //{
            //    var sum = n1 + n2;
            //    return sum.ToString() + "abc";
            //};
            //Console.WriteLine(func("adasdasdas"));
            //Console.WriteLine(func1(2, 3));

            //List<int> lst = null;
            //lst.Where(l => l > 3);

            //var products = new List<Product>()
            //{
            //    new Product() {Id = 1, Qty = 1},
            //    new Product() {Id = 2, Qty = 2},
            //    new Product() {Id = 1, Qty = 3},
            //    new Product() {Id = 1, Qty = 4}
            //};

            //Product a = null;

            //var grp = products.GroupBy(p => p.Id);//.Select(s => new { ProductId = s.Key, Qty = s.Sum(s1 => s1.Qty) });
            //var elementsByKey = grp.First().Select(x => x);

            //if(a != null) return;
            //{
            //    var i = 1;
            //    i++;
            //}

            //var prods = new List<Product>()
            //{
            //    new Product()
            //    {
            //        Id = 1,
            //        Qty = 1,
            //        abc = new ABC() {Id = 1, Name = "1", Child = new Child() {Prop1 = 1, Prop2 = "1"}}
            //    },
            //    new Product() {Id = 1, Qty = 1, abc = new ABC() {Id = 1, Name = "1"}},
            //    new Product() {Id = 1, Qty = 1}
            //};

            //var sortedDictionary = new SortedDictionary<int, string>();
            //sortedDictionary.Add(3,"abc");
            //sortedDictionary.Add(1,"pqr");
            //sortedDictionary.Add(2,"fgh");
            //var e1 = E1.A1;
            //var e2 = (E2) (int) E1.A1;
            //var e3 = (E2)Enum.Parse(typeof(E2), e1.ToString());

            //ABC abc = new ABC(){Id = 1};
            //ABC abc1 = null;
            //var i = abc?.Id ?? 0;
            //var j = (int) abc1?.E1;

            //int? x = null;
            //int? y = null;
            //var b = (x == y);
            //var b1 = x.Equals(y);
            //var b2 = EqualityComparer<int?>.Default.Equals(x, y);
            //ABC a1 = null;
            //ABC a2 = null;
            //var b3 = (Object.Equals(a1,a2));

            //var a = new {x = 1, y = 2};

            var a = new List<int>(){1, 2};
            var b = new List<int>() { 1, 2,3 };
            //var x = a.Except(b);
            //var y = b.Except(a);
            //var prodList = new List<Product>()
            //{
            //    new Product() {Id = 1, Name = "prod1"},
            //    new Product() {Id = 2, Name = "prod2"}
            //};

            //var prod1 = prodList.First(p => p.Id == 1);
            //var newProd1 = new Product() {Id = 1, Name = "prod11"};

            //prodList.Remove(prod1);
            //prodList.Add(newProd1);

            //string a1 = null;
            //string b1 = null;

            //var f = a1 == b1;

            //string E1int1 = ((int) E1.A1).ToString();


            //var x = ABClist.Select(abc => new {pName = dict[abc].Name, abc })

            //(long ShoppingCartItemIdOrLockerItemId, int ServiceId) a11 = (ShoppingCartItemIdOrLockerItemId: 1,
            //    ServiceId: 1);

            //(long ShoppingCartItemIdOrLockerItemId, int ServiceId) a12 = (ShoppingCartItemIdOrLockerItemId: 1,
            //    ServiceId: 2);

            //var removeInventoryItemReservations = new Dictionary<(long ShoppingCartItemIdOrLockerItemId, int ServiceId), List<int>>();
            //removeInventoryItemReservations.Add(a11,new List<int>());
            //var key1 = removeInventoryItemReservations.Keys.FirstOrDefault(k => k.ServiceId == 2);
            //var isKey1Found = false;
            //foreach (var key in removeInventoryItemReservations.Keys)
            //{
            //    if (key.ServiceId == 2)
            //    {
            //        isKey1Found = true;
            //        break;
            //    }
            //}
            //var b1 = key1.Equals(null);
            //var b11 = key1.Equals(default((long, int)));
            //var b111 = removeInventoryItemReservations.ContainsKey((ShoppingCartItemIdOrLockerItemId: 1, ServiceId: 2));
            //key1 = default((long, int));
            //var removeInventoryItemReservations1 = new Dictionary<Tuple<long, int> , List<int>>();
            //removeInventoryItemReservations1.Add(new Tuple<long, int>(1,1), new List<int>() );
            //var key2 = removeInventoryItemReservations1.Keys.FirstOrDefault(k => k.Item2 == 2);
            //var b2 = key2 == null;

            //var b1 = false; var b2 = false;
            //var b3 = true;

            //var x = b1 && b2 || b3;
            //var y = b3 || b1 && b2;

            //var dc = new DerivedClassTest();
            ////var x = dc as DerivedClassTest;
            //var b1 = Conv(dc);

            //bool Conv(BaseClassTest bc)
            //{
            //    var x1 = bc as DerivedClassTest1;
            //    return x1 != null;
            //}

            //Another assembly (ClassLibrary1)
            var baseClass = new ClassLibrary1.BaseClass();
            //baseClass.internalId = 0; cannot access since this is in a different assembly
            baseClass.publicId = 0;
            //baseClass.protectedinternalId = 0; //protected internal can be accessed by any code within the same assembly or from within a  derived class in another assembly
            //baseClass.protectedId   //cannot access. Can only be access from within the class

            var derivedClass = new ClassLibrary1.DerivedClass();
            derivedClass.Id = 0;
            //derivedClass.internalId = 0; cannot access since this is in a different assembly
            derivedClass.publicId = 0;
            //derivedClass.protectedinternalId = 0;//protected internal can be accessed by any code within the same assembly or from within a  derived class in another assembly

            //Same assembly
            var baseClass1 = new ScratchPad.BaseClass();
            baseClass1.internalId = 0; //can access since this is in the same assembly
            baseClass1.publicId = 0;
            baseClass1.protectedinternalId = 0;
            //baseClass.protectedId   //cannot access

            var derivedClass1 = new ScratchPad.DerivedClass();
            derivedClass1.Id = 0;
            derivedClass1.internalId = 0; //cann access since this is in the same assembly
            derivedClass1.publicId = 0;
            derivedClass1.protectedinternalId = 0;
            //derivedClass.protectedId   //cannot access.Can only be access from within the base or derived class

            var aaaa = new ScratchPad.DerivedClassFromExternalAssembly();
            //aaaa.protectedinternalId = 0;//protected internal can be accessed by any code within the same assembly or from within a  derived class in another assembly

        }

        public class BaseClassTest
        {
            public int Id { get; set; }
        }

        public class DerivedClassTest : BaseClassTest
        {

        }

        public class DerivedClassTest1 : BaseClassTest
        {

        }

        public enum E1
        {
            A1 = 1,
            A2 = 2
        }

        public enum E2
        {
            A1 = 1,
            A2 = 2
        }

        public class Product
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Qty { get; set; }

            public  List<ABC> abc { get; set; }
        }

        public class ABC
        {
            public E1 E1 { get; set; }
            public int? Id { get; set; }
            public string Name { get; set; }

            public  Child Child { get; set; }
        }

        public class Child
        {
            public int Prop1 { get; set; }
            public string Prop2 { get; set; }
        }

        public sealed class Singleton
        {
            private static readonly Singleton instance = new Singleton();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Singleton()
            {
            }

            //private Singleton()
            //{
            //}

            public static Singleton Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        public class BaseClass
        {
            public int m_base = 0;
            public BaseClass()
            {
                Console.WriteLine("In base classs constructor");
            }

            //public BaseClass(int i)
            //{
            //    Console.WriteLine("In base classs constructor");
            //}

        }

        public class DerivedClass : BaseClass
        {
            private int m_Drived = 0;
            public DerivedClass(int i)
            {
                Console.WriteLine("In derived classs constructor");
            }

            public async Task<int> GetVal()
            {
                await Task.Delay(1000);
                return 5;
            }
        }

        static void DoSomething(BaseClass bObj,ref int j)
        {
            bObj.m_base = 3;
            j = 5;
        }

        class Test
        {
            public static string x;//= EchoAndReturn("In type initializer");

            static Test()
            {
                x = EchoAndReturn("In type initializer");
            }
            public static string EchoAndReturn(string s)
            {
                Console.WriteLine(s);
                return s;
            }
        }

        

        static bool HasToBeProcessed(A a, List<A> lst)
        {
            return !lst.Any(b => b.Id != a.Id &&
                                  b.ItemId == a.ItemId &&
                                  b.isError.HasValue &&
                                  !b.isError.Value
                                  );
        }

        static void ComplexCheck(int n)
        {
            int? i = null;
            

            if (n == 0 || ((i = GetInt()) == 4))
            {
                //Do something
            }

            i++;

        }

        static int? GetInt()
        {
            return 5;
        }

        static void DoubleLoopBreak()
        {
            for(var i =0;i<5;i++)
            {
                for(var j=0;j<4;j++)
                {
                    if (j == 1 && i == 1)
                        break;
                }
            }
        }

        static int fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            return fibonacci(n - 2) + fibonacci(n - 1);
        }

        //returns false if already exists. Returns true if not existed and assigned
        static bool SafeAssign(int?[] array,int index,int value = -1)
        {
            if (!array[index].HasValue)
            {
                array[index] = value;
                return true;
            }

            return false;
        }

        static int fibonacci(int?[] array,int n)
        {
            //if (n == 0 || n == 1)
            //{
            //    SafeAssign(array, 1, 1);
            //    //array[n] = 1;
            //    return 1;
            //}

            //SafeAssign(array,n, fibonacci(array,n - 2) + fibonacci(array,n - 1));
            //return array[n].Value;

            if (array[n].HasValue)
                return array[n].Value;
            else if(n==0 || n==1)
            {
                array[n] = 1;
                return array[n].Value;
            }
            else
            {
                array[n] = fibonacci(array,n - 1) + fibonacci(array,n - 2);
                return array[n].Value;
            }
        }

        static int GetHashCode(string str)
        {
            var hashCode = 0;
            for(var i = 1;i<=str.Length;i++)
            {
                hashCode += i*str[i-1];
            }
            return hashCode;
        }

        static string GetRandomX9String()
        {
            var returnStr = string.Empty;
            for(int i =0;i<17;i++)
            {
                var r = new Random();
                var d = r.NextDouble();
                if (d >= 0.5)
                    returnStr += "9";
                else
                    returnStr += "X";

            }

            return returnStr;
        }

    }
}
