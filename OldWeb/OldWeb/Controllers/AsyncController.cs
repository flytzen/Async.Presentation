using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldWeb.Controllers
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncController : Controller
    {
        public async Task<ActionResult> Normal()
        {
            var sw = Stopwatch.StartNew();
            var tasks = Enumerable.Range(0, 10).Select(i => this.DosomethingAsync()).ToList();
            foreach (var task in tasks)
            {
                await task;
            }
            sw.Stop();
            return new ContentResult() { Content = sw.ElapsedMilliseconds.ToString("N0") };
        }

        private async Task DosomethingAsync()
        {
            Debug.WriteLine($"Starting on Thread id: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);
            await Task.Delay(1000);
            ////await Task.Delay(1000).ConfigureAwait(false);
            Debug.WriteLine($"Returning on Thread id: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);
        }


    }
}