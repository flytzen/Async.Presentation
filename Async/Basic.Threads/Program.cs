using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Threads
{
    using System.Net.Http;

    class Program
    {
static void Main(string[] args)
{
    Caller().Wait();
}

private static async Task Caller()
{
    var t = "abc";
    var html = await GetSomething();
    Console.WriteLine(html);
}

private static async Task<string> GetSomething()
{
    var url = "http://www.google.com";
    var client = new HttpClient();
    var html = await client.GetStringAsync(url);
    var t = html.Length;
    return html;
}
    }
}
