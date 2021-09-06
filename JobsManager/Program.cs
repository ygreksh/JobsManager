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
            int i;
            for (i = 1; i <= 5; i++)
            {
                
                jobExecutor.Add(new Action(() =>
                {
                
                    int count = i;
                    Console.WriteLine($"Работа {count} началась");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Работа {count} завершилась");
                }));
                
            }

            foreach (var thread in jobExecutor._list)
            {
                thread.Join();
            }
            
            /*
            jobExecutor.Add(new Action(() =>
            {
                Thread myThread = new Thread(() => 
                { 
                    int count = 1;
                    Console.WriteLine($"Работа {count} началась");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Работа {count} завершилась");
                    Thread.Sleep(1000);
                    
                });
                //myThread.Join();
            }));
            jobExecutor.Add(new Action(() =>
            {
                int count = 2;
                Console.WriteLine($"Работа {count} началась");
                Thread.Sleep(1000);
                Console.WriteLine($"Работа {count} завершилась");
                Thread.Sleep(1000);
            }));
            jobExecutor.Add(new Action(() =>
            {
                int count = 3;
                Console.WriteLine($"Работа {count} началась");
                Thread.Sleep(1000);
                Console.WriteLine($"Работа {count} завершилась");
                Thread.Sleep(1000);
            }));
            jobExecutor.Add(new Action(() =>
            {
                int count = 4;
                Console.WriteLine($"Работа {count} началась");
                Thread.Sleep(1000);
                Console.WriteLine($"Работа {count} завершилась");
                Thread.Sleep(1000);
            }));
            jobExecutor.Add(new Action(() =>
            {
                int count = 5;
                Console.WriteLine($"Работа {count} началась");
                Thread.Sleep(1000);
                Console.WriteLine($"Работа {count} завершилась");
                Thread.Sleep(1000);
            }));
            jobExecutor.Add(new Action(() =>
            {
                int count = 6;
                Console.WriteLine($"Работа {count} началась");
                Thread.Sleep(1000);
                Console.WriteLine($"Работа {count} завершилась");
                Thread.Sleep(1000);
            }));
            */
            //jobExecutor.Start(3);
            Thread.Sleep(5000);
            jobExecutor.Stop();
            jobExecutor.Clear();
            Console.ReadKey();
        }
    }
}