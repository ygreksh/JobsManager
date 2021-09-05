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
        //public static Dictionary<int, Thread> ThreadsPool = new Dictionary<int, Thread>();
       
        public JobExecutor()
        {
            //semaphore = new Semaphore(maxConcurrent, maxConcurrent);
        }


        public void Start(int maxConcurrent)
        {
            semaphore = new Semaphore(maxConcurrent, maxConcurrent);
        }

        public void Stop()
        {
            Console.WriteLine("Завершаем все задачи");
            //semaphore.Release();
            //semaphore.Dispose();
        }

        public void Add(Action action)
        {
            semaphore.WaitOne();
            Thread myThread = new Thread(action.Invoke);
            //ThreadsPool.Add(myThread.GetHashCode(),myThread);
            myThread.Start();
            semaphore.Release();
        }

        public void Clear()
        {
            Console.WriteLine("Закрываем семафор");
            semaphore.Close();
        }
    }
}