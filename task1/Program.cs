using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace task1
{
    internal class Program
    {
        static bool isFound = false;
        static object locker = new object();

        static async void BeginSearch(string line, string wantedWord, int temp)
        {
            //lock (locker)
            //{
                if (!isFound && line.Contains(wantedWord))
                {
                    Console.WriteLine($"Found in line : ( {line} ) by thread : {temp + 1}");
                    isFound = true;
                }
            //}
        }

        //static Task<bool> FirstSearch(string sentence, string wantedWord)
        //{

        //    if (sentence.Contains(wantedWord))
        //    {
        //        //Task<int> task = Task.Run(() => PrintY(1000));

        //        //TaskAwaiter<int> taskAwaiter = task.GetAwaiter();
        //        //taskAwaiter.OnCompleted(() => Console.WriteLine($"Result = {task.Result}"));

        //        Console.WriteLine("the first thread found it .");
        //        isFound = true;
        //    }
        //    else
        //        Console.WriteLine("Not Found by first");
        //}

        //static void SecondSearch(string sentence, string wantedWord)
        //{
        //    if (sentence.Contains(wantedWord))
        //    {
        //        Console.WriteLine("the second thread found it .");
        //        isFound = true;
        //    }
        //    else
        //        Console.WriteLine("Not Found by second");
        //}
        //static void ThirdSearch(string sentence, string wantedWord)
        //{
        //    if (sentence.Contains(wantedWord))
        //    {
        //        Console.WriteLine("the thrird thread found it .");
        //        isFound = true;
        //    }
        //    else
        //        Console.WriteLine("Not Found by third");
        //}

        static void Main(string[] args)
        {
            #region task 1 documentation
            //1 - Text Search Engine: Create a multi - threaded application that searches
            //    for a specific word in all lines of a given string.
            //    Each thread should search in one line in the string.
            //    If one thread finds the word, all threads should stop searching. 
            #endregion

            string multiLineString = "In the asdf meadow so asdasd asdklsnfl asfnlfksdnfsdf green.\nasdaskld knqwe  ksfwqiej oiqwereri busy bees at work,\nIn ksdnlf jnflsl wererm mefnfsd their ttttt honey-making scene.";
            string[] strings = multiLineString.Split('\n');
            string wantedWord = "busy";
            Task[] tasks = new Task[strings.Length];

            Console.WriteLine("\n\n");
            for (int i = 0; i < strings.Length; i++)
            {
                int temp = i;

                string trimmedLine = strings[temp].Trim();

                tasks[temp] = Task.Run(() => BeginSearch(trimmedLine, wantedWord, temp));
                Console.WriteLine($"Thread {temp + 1} searching ...");


                if (isFound)
                {
                    break;
                    //foreach(Task task in tasks)
                    //{

                    //}
                }
            }

            //tasks[0].Abort();

            //Task.WaitAll(tasks);

            //if (isFound)
            //{
            //    Console.WriteLine($"found in thread {x}");
            //}
            //else
            //{
            //    Console.WriteLine("not found");
            //}
        }
    }
}
