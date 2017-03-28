namespace IOCP
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            SystemInformation.LogThreadPoolStatus();
            var stopwatch = Stopwatch.StartNew();
            var tasks = Enumerable.Range(1, 100).Select(i => DoSomething()).ToArray();
            SystemInformation.LogThreadPoolStatus();
            Task.WaitAll(tasks);
            stopwatch.Stop();
            SystemInformation.LogThreadPoolStatus();
            Console.WriteLine($"{tasks.Length} took {stopwatch.ElapsedMilliseconds:N0}ms");
            Console.ReadKey();
        }

        private static async Task DoSomething()
        {
            await Task.Delay(1000);
        }
    }
}
