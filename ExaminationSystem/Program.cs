using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new(1, "C#");
            subject.CreateExam();
            Console.Clear();
            Console.WriteLine("Do you want to start the exam (Y | N)");
            char x = char.Parse(Console.ReadLine());
            if(x == 'y' || x == 'Y')
            {
                Console.Clear();
                Stopwatch sw = new();
                sw.Start();
                subject.SubjectExam.ShowExam();
                Console.WriteLine($"Taken Time: {sw.Elapsed}");
            }
            else
            {
                Console.WriteLine("Thank You");
            }


        }
    }
}