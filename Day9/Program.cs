using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Day9
{
    internal class Program
    {
        static bool finish = false;
        static bool printed = false;
        static object obj = new object();

        static int PrintY(int maxNumber)
        {
            int counter = 0;

            for (int i = 0; i < maxNumber; i++)
            {
                Console.Write("Y");

                if(i % 2 == 0)
                    counter++;
            }

            return counter;
        }

        static void NewPrintY()
        {
            while (!finish)
            {
                Console.Write("Y");
            }
        }

        static void Begin()
        {
            PrintY(1000);
        }

        static void PrintMsg()
        {
            lock(obj)
            {
                if (!printed)
                {
                    Console.WriteLine("Hello");
                    printed = true;
                } 
            }
        }

        static async void BeginTask()
        {
            //Task<int> task = Task.Run(() => PrintY(1000));

            //TaskAwaiter<int> taskAwaiter = task.GetAwaiter();
            //taskAwaiter.OnCompleted(() => Console.WriteLine($"Result = {task.Result}"));

            int x = await Print();
            if (x == 2) ;

        }

        static async Task<int> Print()
        {
            int result = await Task.Run(() => PrintY(1000));
            return result;

            //Task<int> task =  Task.Run(() => PrintY(1000));
            //task.GetAwaiter().OnCompleted(() => { Console.WriteLine(""); });

            //return task;

        }

        static void TaskFinished(int result)
        {
            Console.WriteLine($"Result = {result}");
        }

        static async void Main(string[] args)
        {
            #region Thread
            //ThreadStart threadStart = new ThreadStart(PrintY);
            //Thread th = new Thread(threadStart);

            //Thread th = new Thread(PrintY);
            //Thread th = new Thread(Begin);
            //int x = 1000;
            //Thread th = new Thread(() => PrintY(x));
            //Thread th = new Thread(() => NewPrintY());
            //th.IsBackground = true;
            //th.Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write("X");
            //    if (i == 90)
            //        finish = true;

            //    //if(i == 90)
            //    //    th.Join();
            //}

            //th.Join();

            //Console.WriteLine("Finish");

            //Thread.Sleep(TimeSpan.FromSeconds(2));

            //Thread th = new Thread(PrintMsg);
            //th.Start();

            //PrintMsg(); 
            #endregion

            Task task = Task.Run(() => PrintY(1000));
            Task task2 = Task.Run(() => PrintY(1000));
            Task task3 = Task.Run(() => PrintY(1000));
            await Task.WhenAll(task, task2, task3);

            BeginTask();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");

                //if (i == 900)
                //    task.Wait(2000);
            }

            //Task.WhenAll(task, task2, task3);
            //Task.WhenAny(task, task2, task3);
        }
    }
}