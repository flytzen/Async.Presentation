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

    public class ExplainAsyncThreadsController : Controller
    {
public async Task<ActionResult> Index()
{
    var firstTask = GetContentLength("https://www.google.com");
    var secondTask = GetContentLength("https://www.microsoft.com");
    var firstThing = await firstTask.ConfigureAwait(false);
    // Maybe do something
    var secondThing = await secondTask.ConfigureAwait(false);
    return View();
}

private static async Task<int> GetContentLength(string url)
{
    var httpClient = new HttpClient();
    var html = await httpClient.GetStringAsync(url).ConfigureAwait(false);
    var length = html.Length;
    return length;
}
    }
}