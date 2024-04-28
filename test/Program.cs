using System;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static bool isFound = false;

        static void SearchThread(string line, string targetWord)
        {
            if (!isFound && line.Contains(targetWord))
            {
                Console.WriteLine($"Thread found the word in line: {line}");
                isFound = true; // Set the flag to stop other threads
            }
        }

        static void Main(string[] args)
        {
            string multiLineString = "Your multiline string here...";
            string[] lines = multiLineString.Split('\n');

            string targetWord = "wordToSearch";

            Task[] tasks = new Task[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                tasks[i] = Task.Run(() => SearchThread(lines[i], targetWord));
            }

            Task.WaitAny(tasks); // Wait for any task to finish

            if (isFound)
            {
                Console.WriteLine("Word found. Stopping all other threads.");
                // Cancel all other tasks
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i].Wait(); // Wait for all tasks to complete (optional)
                }
            }
            else
            {
                Console.WriteLine("Word not found in any line.");
            }
        }
    }
}
