﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Model
{
    class DuplexItem<T>
    {
        public T Data { get; set; }

        public Item<T> Next { get; set; }

        public Item<T> Previous { get; set; }

        public DuplexItem(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
