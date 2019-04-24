using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    class Program
    {
        static IQueueWriter queueWriter;
        static void Main(string[] args)
        {
        }

        private static async Task Slow(IEnumerable<Message> messages)
        {
            foreach (var message in messages)
            {
                await queueWriter.Write(message);
            }
        }

        private static async Task Naive(IEnumerable<Message> messages)
        {
            var tasks = messages.Select(m => queueWriter.Write(m)).ToList();
            await Task.WhenAll(tasks);
        }

        private static async Task UsuallyFine(IEnumerable<Message> messages)
        {
            var tl = new List<Task>();
            var sem = new SemaphoreSlim(100);
            foreach (var message in messages)
            {
                await sem.WaitAsync();
                tl.Add(queueWriter.Write(message).ContinueWith(t => sem.Release()));
            }
            await Task.WhenAll(tl);
        }

        

    }


    public class Message { }

    public interface IQueueWriter
    {
        Task Write(Message message);
    }
}
