using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Async.ReturnTask
{
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine($"Memory before: {GC.GetTotalMemory(true):N0}");
            var tasks = Enumerable.Range(1, 1000).Select(i => DoSomething(i)).ToList();
            sw.Stop();
            Console.WriteLine($"Tasks started after {sw.Elapsed}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            GC.Collect();
            Console.WriteLine($"Memory with {tasks.Count} tasks: {GC.GetTotalMemory(true):N0}");
            foreach (var task in tasks)
            {
                task.Wait();
            }
            GC.Collect();
            Console.WriteLine($"Memory after tasks finished: {GC.GetTotalMemory(true):N0}");

            Console.ReadKey();

        }

        private static Task DoSomething(int input)
        {
            var t = 100;
            var t2 = input * t;
            return Task.Delay(TimeSpan.FromSeconds(10));
        }
    }
}
