using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenAllLimits
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Enumerable.Range(1, 1000).Select(async i  => await Task.Delay(10));
            Task.WhenAll(tasks);
            Console.WriteLine("done");
        }
    }
}
