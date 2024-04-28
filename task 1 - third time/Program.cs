

namespace task_1___third_time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string multiLineString = "In the asdf meadow so asdasd asdf  asfnlfksdnfsdf green.\nasdaskld knqwe  ksfwqiej dasdd  asdewe bees busy at work,\nIn ksdnlf jnflsl wererm  mefnfsd their ttttt honey-making  scene.";
            string[] lines = multiLineString.Split('\n');
            string target = "busy";

            Thread[] myThreads = new Thread[lines.Length];

            myThreads[0] = new Thread(() => Search(lines[0], target, myThreads));
            myThreads[0].Name = "first";

            myThreads[1] = new Thread(() => Search(lines[1], target, myThreads));
            myThreads[1].Name = "second";

            myThreads[2] = new Thread(() => Search(lines[2], target, myThreads));
            myThreads[2].Name = "third";

            myThreads[0].Start();
            myThreads[1].Start();
            myThreads[2].Start();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            //foreach (Thread thread in myThreads)
            //{
            //    thread.Join();
            //}

            //while (!found)
            //{
            //    if (myTasks[i].IsCompleted && found)
            //    {
            //        Console.WriteLine($"Thread number {i + 1} found it .");
            //        break;
            //    }
            //}

            //Console.ReadLine();
        }

        static bool found = false;
        static object locker = new object();

        private static void Search(string line, string target, Thread[] myThreads)
        {
            //lock (locker)
            //{
                if (line.Contains(target) && !found)
                {
                    found = true;
                    Console.WriteLine($"The {Thread.CurrentThread.Name} Thread found it . ");
                    Console.WriteLine($"Aborting all threads now ... ");
                    AbortAllThreads(myThreads);
                }
            //}
        }

        private static void AbortAllThreads(Thread[] myThreads)
        {
            foreach (Thread thread in myThreads)
            {
                try
                {
                    if (thread == Thread.CurrentThread)
                        continue;

                    thread.Abort();
                }
                catch (Exception exc)
                {
                    // I know that Abort is depricated but I don't know another solution ...
                }
            }
            try
            {
                Thread.CurrentThread.Abort();
            }
            catch (Exception exc)
            {
                // do no thing ...
            }
        }
    }
}
