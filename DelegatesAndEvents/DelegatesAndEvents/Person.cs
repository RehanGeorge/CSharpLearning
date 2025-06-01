using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate int Comparison<T>(T x, T y);

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class PersonSorter
    {
        public static void Sort(Person[] people, Comparison<Person> comparison)
        {
            for(int i = 0; i < people.Length - 1; i++)
            {
                for(int j = i + 1; j < people.Length; j++)
                {
                    // Compare people[i] and people[j] using the provided comparison delegate
                    if (comparison(people[i], people[j]) > 0)
                    {
                        // Swap the elements if they are in the wrong order
                        Person temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }
        }
    }
}
