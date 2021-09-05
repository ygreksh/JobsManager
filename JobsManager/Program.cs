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
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 1 началась");
                Thread.Sleep(1000);
                Console.WriteLine("Работа 1 завершилась");
            });
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 2 началась");
                Thread.Sleep(1000);
                Console.WriteLine("Работа 2 завершилась");
            });
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 3 началась");
                Thread.Sleep(1000);
                Console.WriteLine("Работа 3 завершилась");
            });
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 4 началась");
                Thread.Sleep(1000);
                Console.WriteLine("Работа 4 завершилась");
            });
            jobExecutor.Add(() =>
            {
                Console.WriteLine("Работа 5 началась");
                Thread.Sleep(1000);
                Console.WriteLine("Работа 5 завершилась");
            });
            //jobExecutor.Start(3);
            Thread.Sleep(8000);
            jobExecutor.Stop();
            jobExecutor.Clear();
            Console.ReadKey();

        }
    }
}