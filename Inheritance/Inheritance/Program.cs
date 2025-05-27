namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Dog fido = new Dog();
            fido.MakeSound();
            fido.Eat();

            BaseClass baseClass = new BaseClass();
            baseClass.ShowFields();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.AccessFields();
            baseClass.ShowFields();
            derivedClass.ShowFields();

            Employee joe = new Employee("Joe", 26);
            joe.DisplayPersonInfo();
        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    class Dog: Animal
    {

        public override void MakeSound()
        {
            base.MakeSound();
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
