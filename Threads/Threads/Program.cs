using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enumerable.Range(0, 1000).ToList().ForEach(f =>
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(1000); // Simulate some work
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} finished");
                }).Start();
            });
        }
    }
}
