using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10, "C#");
            sub1.CreateExam();
            Console.Clear();
            char input;
            do
            {
                Console.Write("Do You Want to Start the Exam (y | n): ");
                input = char.Parse(Console.ReadLine());
                if (input == 'y')
                {
                    Console.Clear();
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();
                    sub1.Exam.ShowExam();
                    Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
                }
                else if (input == 'n')
                {
                    Console.WriteLine("No Exam");
                    break;
                }
            } while (input != 'y' || input != 'n');
        }
    }
}
