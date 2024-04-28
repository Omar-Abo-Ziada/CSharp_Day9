using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static bool isFound = false;

        static async void FirstSearch(string sentence, string wantedWord)
        {
            if (sentence.Contains(wantedWord))
            {
                //Task<int> task = Task.Run(() => PrintY(1000));

                //TaskAwaiter<int> taskAwaiter = task.GetAwaiter();
                //taskAwaiter.OnCompleted(() => isFound = true);

                Console.WriteLine("the first thread found it .");
                isFound = true;
            }
            else
                Console.WriteLine("Not Found by first");
        }
        static void SecondSearch(string sentence, string wantedWord)
        {
            if (sentence.Contains(wantedWord))
            {
                Console.WriteLine("the second thread found it .");
                isFound = true;
            }
            else
                Console.WriteLine("Not Found by second");
        }
        static void ThirdSearch(string sentence, string wantedWord)
        {
            if (sentence.Contains(wantedWord))
            {
                Console.WriteLine("the thrird thread found it .");
                isFound = true;
            }
            else
                Console.WriteLine("Not Found by third");
        }

        static async void Main(string[] args)
        {
            string multiLineString = "In the busy meadow so green.\nbusy bees at work,\nIn their busy honey-making scene.";

            string[] strings = multiLineString.Split('\n');

            //Console.WriteLine(strings[0]);
            //Console.WriteLine(strings[1]);
            //Console.WriteLine(strings[2]);

            string wantedWord = "busy";

            //if (strings[0].Contains("busy"))
            //    Console.WriteLine("OK");
            //else
            //    Console.WriteLine("Not Found");


            Task task1 = Task.Run(() => FirstSearch(strings[0], wantedWord));
            Task task2 = Task.Run(() => SecondSearch(strings[1], wantedWord));
            Task task3 = Task.Run(() => ThirdSearch(strings[2], wantedWord));

            await Task.WhenAny(task1, task2, task3);

        }
    }
}
