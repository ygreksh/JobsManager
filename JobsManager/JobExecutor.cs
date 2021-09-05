using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace JobsManager
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount { get; }
        public Semaphore semaphore;
        public static Dictionary<int, Thread> ThreadsPool = new Dictionary<int, Thread>();

        /*
        public void JobExecutor()
        {
            ThreadsPool = new Dictionary<int, Thread>();
        }
        */
        
        public void Start(int maxConcurrent)
        {
            semaphore = new Semaphore(maxConcurrent, maxConcurrent);
        }

        public void Stop()
        {
            semaphore.Release();
        }

        public void Add(Action action)
        {
            Thread myThread = new Thread(action.Invoke);
            ThreadsPool.Add(myThread.GetHashCode(),myThread);
            semaphore.WaitOne();
        }

        public void Clear()
        {
            semaphore.Close();
        }
    }
}