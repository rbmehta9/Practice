﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable3
{
    public interface Iterable<T>
    {
        IIterator<T> GetIterator();
    }
}
