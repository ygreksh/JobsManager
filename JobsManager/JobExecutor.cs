using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace JobsManager
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount { get; }
        public static Semaphore semaphore;
        //public static Dictionary<int, Thread> ThreadsPool = new Dictionary<int, Thread>();
        public List<Thread> _list;
        public JobExecutor()
        {
            //semaphore = new Semaphore(maxConcurrent, maxConcurrent);
            _list = new List<Thread>();
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
            Thread myThread = new Thread(() =>
            {
                action.Invoke();
                int r  = semaphore.Release();
                Console.WriteLine($"В семафоре {r} потоков");
            });
            _list.Add(myThread);
            myThread.Start();
            //myThread.Join();
            //int r  = semaphore.Release();
            //myThread.Join();
            //Console.WriteLine($"В семафоре {r} потоков");
        }

        public void Clear()
        {
            Console.WriteLine("Закрываем семафор");
            semaphore.Close();
            _list.Clear();
        }
    }
}