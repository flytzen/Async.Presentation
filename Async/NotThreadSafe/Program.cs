namespace NotThreadSafe
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        // NOTE: Best run in Release mode
        public static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(100, 100);
            var tester = new Tester();
            var result = tester.Run().Result;
            Console.ReadKey();
        }
    }

public class Tester
{
    private const int TaskCount = 1000;

    private const int LoopCount = 10;

    private int total;

    public async Task<int> Run()
    {
        var tasks = Enumerable.Range(0, TaskCount).Select(i => this.DoSomething()).ToList();  // NOTE: ToList essential to get this to run in parallel!
        Console.WriteLine($"{TaskCount} tasks started");
        foreach (var task in tasks)
        {
            await task.ConfigureAwait(false);
        }

        Console.WriteLine($"Expected: {TaskCount * LoopCount:N0}. Actual: {this.total:N0}");
        return this.total;
    }

    private async Task DoSomething()
    {
        for (int i = 0; i < LoopCount; i++)
        {
            // Simulate some async work
            await Task.Delay(100).ConfigureAwait(false);
                
            // Simulate CPU bound behaviour
            Thread.Sleep(10); 
                
            // NOTE: Uncommenting the following line will slow it down enough that you probably won't see the problem
            // Console.WriteLine($"On thread {Thread.CurrentThread.ManagedThreadId}");
            this.total = this.total + 1;
            //// Interlocked.Increment(ref this.total);
        }
    }
}
}
