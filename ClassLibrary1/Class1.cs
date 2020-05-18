using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
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
            protectedinternalId = 0;
            
        }
        public int Id { get; set; }
    }

    public class D
    {
        public D()
        {
            var derivedClass = new DerivedClass();
            derivedClass.internalId = 0;
            derivedClass.protectedinternalId = 0;
        }
    }
}
