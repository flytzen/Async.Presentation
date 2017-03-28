using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldWeb.Controllers
{
    using System.Net.Configuration;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeadlockSyncController : Controller
    {
        // GET: DeadlockAlways
public ActionResult Index(bool doItFast)
{
    var text = this.DoSomething(doItFast).Result;
    return View();
}

private async Task<string> DoSomething(bool doitfast)
{
    if (doitfast)
    {
        return await Task.FromResult("some cached value");
    }
    else
    {
        var client = new HttpClient();
        return await client.GetStringAsync("https://www.google.com");
    }
}
    }
}