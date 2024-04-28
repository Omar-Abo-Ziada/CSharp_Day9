using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace task_2_another_sol
{
    internal class Program
    {
        static bool found = false;
        static object locker = new object();
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Search(string line, string target, int temp, List<Task> myTasks, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            if (!found && line.Contains(target))
            {
                lock (locker)
                {
                    if (!found)
                    {
                        found = true;
                        Console.WriteLine($"Thread number {temp + 1} found it . ");
                        Console.WriteLine($"Cancelling all tasks ...");
                        cts.Cancel();
                        ClearAllTasks(myTasks);
                    }
                }
            }
        }

        private static void ClearAllTasks(List<Task> myTasks)
        {
            foreach (Task task in myTasks)
            {
                // You can cancel the task if it's still running
                // Otherwise, you can just ignore it
            }
        }

        static void Main(string[] args)
        {
            string multiLineString = "In the asdf meadow so asdasd asdklsnfl  asfnlfksdnfsdf green.\nasdaskld knqwe  ksfwqiej oiqwerer  bees at work,\nIn ksdnlf jnflsl busy wererm  mefnfsd their ttttt honey-making scene.";
            string[] lines = multiLineString.Split('\n');
            string target = "busy";

            List<Task> myTasks = new List<Task>();

            for (int i = 0; i < lines.Length; i++)
            {
                int temp = i; // to avoid captured variable problem
                // temp is local to each iteration

                myTasks.Add(Task.Run(() => Search(lines[temp], target, temp, myTasks, cts.Token), cts.Token));
            }

            Task.WaitAll(myTasks.ToArray());

            while (!found)
            {
                for (int i = 0; i < myTasks.Count; i++)
                {
                    if (myTasks[i].IsCompleted && found)
                    {
                        Console.WriteLine($"Thread number {i + 1} found it.");
                        break;
                    }
                }
            }
        }
    }
}
