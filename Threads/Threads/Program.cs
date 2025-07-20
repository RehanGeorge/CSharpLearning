using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World! 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World! 2");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World! 3");
            Thread.Sleep(1000);
            */

            /*
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 2");
            }).Start();

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 3");
            }).Start();
            */

            var taskCompletionSource = new TaskCompletionSource<bool>();

            var thread = new Thread(() =>
            {
                taskCompletionSource.TrySetResult(true);
            });
            Console.WriteLine($"Thread number: {thread.ManagedThreadId}");
            thread.Start();
            var test = taskCompletionSource.Task.Result;

            int[] numbersArray = new int[100];
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbersArray[i] = i;
            }

            var evenCalcThread = new Thread(() =>
            {
                for (int i = 0; i < numbersArray.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"Thread 2: {numbersArray[i]}");
                    }
                }
            });
            evenCalcThread.Start();

            var oddCalcThread = new Thread(() =>
            {
                for (int i = 0; i < numbersArray.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.WriteLine($"Thread 3: {numbersArray[i]}");
                    }
                }
            });
            oddCalcThread.Start();
        }
    }
}
