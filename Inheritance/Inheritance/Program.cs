namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Dog fido = new Dog();
            fido.Bark();
            fido.Eat();
        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }

    class Dog: Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }
    }

    class Collie : Dog
    {
        public void GoingNuts()
        {
            Console.WriteLine("Collie going nuts");
        }
    }

    class Cat: Animal
    {
        public void Meow()
        {
            Console.WriteLine("Cat is meowing...");
        }
    }
}
