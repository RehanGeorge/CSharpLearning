using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class NewBox<T>
    {
        private T content;

        public NewBox(T initialValue)
        {
            content = initialValue;
        }

        public void UpdateContent(T newValue)
        {
            content = newValue;
            Console.WriteLine($"Content updated to: {content}");
        }

        public T Value
        {
            get { return content; }
        }
    }
}
