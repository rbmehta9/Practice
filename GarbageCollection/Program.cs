using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> trackinglist = new List<object>();
            using (null)
            {
                //List<object> trackinglist2 = new List<object>();
                var d1 = new TestDispose("d1", trackinglist);
            }

            //Thread.Sleep(2000);

            using (var d2 = new TestDispose("d2", trackinglist))
            {

            }

            using (null)
            {
                var d3 = new TestDispose("d3", trackinglist);
                d3.Dispose();
            }

            using (null)
            {
                var d4 = new TestDispose("d4", trackinglist);
            }

            Console.WriteLine($"Number of object to dispose : {trackinglist.Count}");
            foreach (TestDispose d in trackinglist)
            {
                Console.WriteLine("    Reference Object: {0:s}, {1:x16}",
                d.InstanceName, d.GetHashCode());
            }


            Console.WriteLine("\nDequeueing finalizers...");
        }
    }

    public class TestDispose : IDisposable
    {
        private bool disposed = false;
        private string _instanceName;
        private List<object> trackinglist;
        private IntPtr unmanagedResource;

        public string InstanceName
        {
            get
            {
                return _instanceName;
            }
        }
        public TestDispose(string instanceName, List<object> tracking)
        {
            _instanceName = instanceName;
            trackinglist = tracking;
            trackinglist.Add(this);
            unmanagedResource = Marshal.StringToCoTaskMemAuto(instanceName);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //Release Managed resources
                    Console.WriteLine($"[{_instanceName}]:Dispose:true");
                    trackinglist.Remove(this);
                }
                else
                {
                    Console.WriteLine($"[{_instanceName}]:Dispose:true:Finalization");
                }

                disposed = true;

                //Release Unmanaged Resources
                if (unmanagedResource != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(unmanagedResource);
                    Console.WriteLine("[{0}] Unmanaged memory freed at {1:x16}", _instanceName, unmanagedResource.ToInt64());
                    unmanagedResource = IntPtr.Zero;
                }
            }
        }

        ~TestDispose()
        {
            Console.WriteLine($"[{_instanceName}]:Finalization");
            Dispose(false);
        }
    }


}



