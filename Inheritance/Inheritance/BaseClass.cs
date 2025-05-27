using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class BaseClass
    {
        public int publicField;
        protected int protectedField;
        private int privateField;

        public void ShowFields()
        {
            Console.WriteLine($"Public: {publicField}, " + $"Protected: {protectedField}, Private: {privateField}");
        }
    }

    class DerivedClass : BaseClass
    {
        public void AccessFields()
        {
            publicField = 1;
            protectedField = 2;
            //privateField = 3;
        }
    }
}
