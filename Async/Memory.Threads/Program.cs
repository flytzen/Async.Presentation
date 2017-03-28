using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Threads
{
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
static void Main(string[] args)
{
    var sw = Stopwatch.StartNew();
    Console.WriteLine($"Memory before: {GC.GetTotalMemory(true):N0}");
    var threads = Enumerable.Range(1, 1000).Select(i => new Thread(() => DoSomething(i))).ToList();
    foreach (var thread in threads)
    {
        thread.Start();
    }
    sw.Stop();
    Console.WriteLine($"Threads started after {sw.Elapsed}");
    Thread.Sleep(TimeSpan.FromSeconds(1));
    GC.Collect();
    Console.WriteLine($"Memory with {threads.Count} threads: {GC.GetTotalMemory(true):N0}");

    foreach (var thread in threads)
    {
        thread.Join();
    }
    GC.Collect();
    Console.WriteLine($"Memory after threads finished: {GC.GetTotalMemory(true):N0}");

    Console.ReadKey();

}

private static int DoSomething(int input)
{
    var t = 100;
    var t2 = input * t;
    Thread.Sleep(TimeSpan.FromSeconds(60));
    return t2;
}
    }
}
