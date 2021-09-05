using System;
using System.Threading;

namespace JobsManager
{
    class Program
    {
        static void Main(string[] args)
        {
            JobExecutor jobExecutor = new JobExecutor();
            jobExecutor.Start(3);
            
            for (int i = 0; i < 5; i++)
            {
                
                jobExecutor.Add(new Action(() =>
                {
                    int count = i;
                    Console.WriteLine($"Работа {count} началась");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Работа {count} завершилась");
                    Thread.Sleep(1000);
                }));
            }
            //jobExecutor.Start(3);
            Thread.Sleep(5000);
            jobExecutor.Stop();
            jobExecutor.Clear();
            Console.ReadKey();
        }
    }
}