using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10 , "C#");
            sub1.CreateExam();
            Console.Clear();
            Console.Write("Do You Want to Start the Exam (y | n): ");

            if(char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                sub1.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
        }
    }
}
