using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Box<T>
    {
        public T Content { get; set; }

        public string Log()
        {
            return $"Box contains {Content}";
        }
    }
}
