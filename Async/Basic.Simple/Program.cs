using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Simple
{
    using System.Net.Http;
    using System.Threading;

    using Util;

    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(20, 20);
            Util.Utils.LogThreadPoolStatus();
            Console.WriteLine();
            Console.WriteLine($"MAIN started on thread {Thread.CurrentThread.ManagedThreadId}. Is threadpool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Run().Wait();
            Console.WriteLine($"MAIN finished on thread {Thread.CurrentThread.ManagedThreadId}. Is threadpool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Util.Utils.LogThreadPoolStatus();
            Console.ReadKey();
        }

        private static async Task Run()
        {
            Console.WriteLine($"RUN started on thread {Thread.CurrentThread.ManagedThreadId}. Is threadpool thread: {Thread.CurrentThread.IsThreadPoolThread}");

            var tasks = Enumerable.Range(1, 3).Select(c => JustWait(c)).ToList();
            //var tasks = Enumerable.Range(1, 3).Select(c => DoSomeIO(c)).ToList();
            foreach (var task in tasks)
            {
                await task;
            }
            Console.WriteLine($"RUN finished on thread {Thread.CurrentThread.ManagedThreadId}. Is threadpool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Utils.LogThreadPoolStatus();
            Console.WriteLine("");
        }

        private static async Task JustWait(int counter)
        {
            Console.WriteLine($"Task {counter} started on thread {Thread.CurrentThread.ManagedThreadId}. Is threadpool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine($"Task {counter} returned on thread {Thread.CurrentThread.ManagedThreadId}. Is threadpool thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Util.Utils.LogThreadPoolStatus();
            Console.WriteLine();
            // Uncomment the next line to for more threadpool threads to be started
            // Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        public static async Task<int> DoSomeIO()
        {
            var client = new HttpClient();
            var html = await client.GetStringAsync("http://www.google.com");
            var length = html.Length;
            return length;
        }


    }
}
