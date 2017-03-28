namespace IOCP
{
    using System;
    using System.Threading;

    public static class SystemInformation
    {
        public static void LogThreadPoolStatus()
        {
            int minWorkerThreads;
            int minIOCPThreads;
            int maxWorkerThreads;
            int maxIOCPThreads;
            int availableWorkerThreads;
            int availableIOCPThreads;
            int activeWorkerThreads;
            int activeIOCPThreads;
            ThreadPool.GetMinThreads(out minWorkerThreads, out minIOCPThreads);
            ThreadPool.GetAvailableThreads(out availableWorkerThreads, out availableIOCPThreads);
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxIOCPThreads);
            activeWorkerThreads = maxWorkerThreads - availableWorkerThreads;
            activeIOCPThreads = maxIOCPThreads - availableIOCPThreads;

            Console.WriteLine($"ThreadPool status.\nIOCP: Active={activeIOCPThreads}, Min={minIOCPThreads}, Max={maxIOCPThreads} \nWorker: Active={activeWorkerThreads}, Min={minWorkerThreads}, Max={maxWorkerThreads}");
        }
    }
}
