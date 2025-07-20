using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Main Thread started");
            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);
            thread1.Start();
            thread2.Start();

            if(thread1.Join(1000))
            {
                Console.WriteLine("Thread1Function done");
            }
            else
            {
                Console.WriteLine("Thread1Function wasn't done within 1 sec");
            }

            thread2.Join();
            Console.WriteLine("Thread2Function done");

            Console.WriteLine("Main Thread ended");

            /*
            Enumerable.Range(0, 100).ToList().ForEach(f =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread number: {Environment.CurrentManagedThreadId} started");
                    Thread.Sleep(1000); // Simulate some work
                    Console.WriteLine($"Thread number: {Environment.CurrentManagedThreadId} finished");
                });
            });

            Console.ReadLine();
            */
        }

        public static void Thread1Function()
        {
            Console.WriteLine("Thread1 Function started");
            Thread.Sleep(2000);
            Console.WriteLine("Thread1Function coming back to caller");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2 Function started");
        }
    }
}
