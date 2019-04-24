using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPNetCore.Controllers
{
    public class AsyncController : Controller
    {
        private readonly ILogger logger;

        public AsyncController(ILogger<AsyncController> logger)
        {
            this.logger = logger;
        }

        public async Task<IActionResult> Normal()
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
            this.logger.LogInformation($"Starting on Thread id: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);
            await Task.Delay(1000);
            ////await Task.Delay(1000).ConfigureAwait(false);
            this.logger.LogInformation($"Returning on Thread id: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(1000);
        }
        
    }
}