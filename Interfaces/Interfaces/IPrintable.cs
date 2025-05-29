using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IPrintable
    {
        void Print();
    }

    public interface IScannable
    {
        void Scan();
    }

    public class MultiFunctionPrinter : IPrintable, IScannable
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }
        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }
    }
}
