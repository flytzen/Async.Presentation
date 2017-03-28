using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldWeb.Controllers
{
    using System.Threading.Tasks;

    public class DeadlockAlwaysController : Controller
    {
        // GET: DeadlockAlways
public ActionResult Index()
{
    this.DoSomething().Wait();
    return View();
}

private async Task DoSomething()
{
    await Task.Delay(100).ConfigureAwait(false);
    var t = 1 + 2;
}
    }
}