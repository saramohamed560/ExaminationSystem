using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuetions { get; set; }
        public Question[] ListOfQuestions { get; set; }
        public Exam(int time , int numberOfQuestions)
        {
            Time = time;
            NumberOfQuetions = numberOfQuestions;
        }
        public abstract void ShowExam();
        public abstract void CreateListOfQuestions();

    }
}
