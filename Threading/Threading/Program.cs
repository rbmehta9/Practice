using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    //public class Class1
    //{
    //    private static ReaderWriterLock lck = new ReaderWriterLock();
    //    private static int _number = 0;
    //    public static int Number
    //    {
    //        get
    //        {
    //            try
    //            {
    //                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} acquiring number");
    //                lck.AcquireReaderLock(Timeout.Infinite);
    //                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} done acquiring number");
    //                lck.ReleaseReaderLock();
    //            }
    //            finally
    //            {
    //                lck.ReleaseLock();
    //            }
    //            return _number;
    //        }
    //        set
    //        {
    //            try
    //            {
    //                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} changing number");
    //                lck.AcquireWriterLock(Timeout.Infinite);
    //                //var rnd = new Random(3);
    //                _number = value;
    //                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} done changing number to {_number}");
    //                lck.ReleaseWriterLock();
    //            }
    //            finally
    //            {
    //                lck.ReleaseLock();
    //            }
    //            //_number = value;

    //        }

    //    }
    //}

    public class class2
    {
        private List<int> _sharedArr = new List<int>();
        private ReaderWriterLock lck = new ReaderWriterLock();
        private bool isFinishedUpdating = false;
        public void Setup()
        {
            var thUpdateInMemoryArray1 = new Thread(new ThreadStart(() =>
            {
                var rnd = new Random();
                
                while (_sharedArr.Count <= 100)
                {
                    var num = rnd.Next(0, 1000);
                    Thread.Sleep(5);
                    lck.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        _sharedArr.Add(num);
                        if (_sharedArr.Count == 100)
                            isFinishedUpdating = true;
                    }
                    finally
                    {
                        lck.ReleaseWriterLock();
                    }

                }

            }));

            var thUpdateInMemoryArray2 = new Thread(new ThreadStart(() =>
            {
                var rnd = new Random();

                while (_sharedArr.Count <= 100)
                {
                    var num = rnd.Next(0, 1000);
                    Thread.Sleep(5);
                    lck.AcquireWriterLock(Timeout.Infinite);
                    try
                    {
                        _sharedArr.Add(num);
                        if (_sharedArr.Count == 100)
                            isFinishedUpdating = true;
                    }
                    finally
                    {
                        lck.ReleaseWriterLock();
                    }

                }
            }));

            var thPollingArray1 = new Thread(new ThreadStart(() =>
            {
                var i = 0;
                Thread.Sleep(3000);
                while (!isFinishedUpdating || i < _sharedArr.Count)
                {
                    try
                    {
                        lck.AcquireReaderLock(Timeout.Infinite);
                        Thread.Sleep(50);
                        if (_sharedArr.Count > i)
                            Console.WriteLine($"Reading element at {i} with value {_sharedArr[i]} by thread thPollingArray");
                        //lck.ReleaseReaderLock();
                    }
                    finally
                    {
                        lck.ReleaseReaderLock();
                    }

                    i++;

                }
            }));

            var thPollingArray2 = new Thread(new ThreadStart(() =>
            {
                var i = 0;
                Thread.Sleep(4000);
                while (!isFinishedUpdating || i < _sharedArr.Count)
                {
                    try
                    {
                        lck.AcquireReaderLock(Timeout.Infinite);
                        Thread.Sleep(50);
                        if (_sharedArr.Count > i)
                            Console.WriteLine($"Reading element at {i} with value {_sharedArr[i]} by thread thPollingArray2");
                        //lck.ReleaseReaderLock();
                    }
                    finally
                    {
                        lck.ReleaseReaderLock();
                    }

                    i++;

                }
            }));

            thUpdateInMemoryArray1.Start();
            thUpdateInMemoryArray2.Start();
            thPollingArray1.Start();
            thPollingArray2.Start();

            thUpdateInMemoryArray1.Join();
            thUpdateInMemoryArray2.Join();
            thPollingArray1.Join();
            thPollingArray2.Join();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cls = new class2();
            cls.Setup();
            Console.Read();
        }
    }
}
