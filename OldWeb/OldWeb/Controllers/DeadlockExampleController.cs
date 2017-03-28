using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldWeb.Controllers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeadlockExampleController : Controller
    {
        // GET: DeadlockAlways
public async Task<ActionResult> Index()
{
    var task = this.DoSomething();
    await Task.Delay(5000);
    task.Wait();
    return View();
}

private async Task DoSomething()
{
    var client = new HttpClient();
    var html = await client.GetStringAsync("https://www.google.com");
    var t = 1 + 2;
}
    }
}