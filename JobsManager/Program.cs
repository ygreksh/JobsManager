using System;
using System.Threading;

namespace JobsManager
{
    class Program
    {
        static void Main(string[] args)
        {
            JobExecutor jobExecutor = new JobExecutor();
            //jobExecutor.Start(3);
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 1");
                Thread.Sleep(1000);
            });
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 2");
                Thread.Sleep(1000);
            });
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 3");
                Thread.Sleep(1000);
            });
            jobExecutor.Start(3);
            Thread.Sleep(6000);
            jobExecutor.Stop();
            jobExecutor.Clear();
            Console.ReadKey();

        }
    }
}