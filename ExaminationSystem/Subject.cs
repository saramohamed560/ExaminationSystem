using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Subject
    {
        public int SubjectId {  get; set; }
        public string? SubjectName { get; set; }

        public Exam SubjectExam { get; set; }

        public Subject(int id,string name)
        {
            SubjectId = id;
            SubjectName = name;
        }
        public void CreateExam()
        {
            int ExamType, Time, NumberOfQuestions;
            do
            {
                Console.WriteLine("Enter 1 for Practical Exam or 2 for Final EXam");
            } while (!int.TryParse(Console.ReadLine(), out ExamType) && ExamType < 1 || ExamType > 2);

            do
            {
                Console.WriteLine("Enter Time Of Exam (30 to 100 min)");
            } while (!int.TryParse(Console.ReadLine(), out Time) || (Time < 30 || Time > 100));
            do
            {
                Console.WriteLine("Enter Number Of  Questions");
            } while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions)||(NumberOfQuestions<1));

            if (ExamType == 1)
            {
                SubjectExam = new PracticalExam(Time, NumberOfQuestions);
            }
            else
                SubjectExam = new FinalExam(Time, NumberOfQuestions);
            Console.Clear();
            SubjectExam.CreateListOfQuestions();
        }

        
    }
}
