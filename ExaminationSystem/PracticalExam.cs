using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time , int numberofQuestions):base(time,numberofQuestions)
        {
            
        }
        public override void CreateListOfQuestions()
        {
            ListOfQuestions = new MCQQuestion[NumberOfQuetions];
            for (int i = 0; i < NumberOfQuetions; i++)
            {
                ListOfQuestions[i]= new MCQQuestion();
                ListOfQuestions[i].AddQuestion();
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            foreach (var Question in ListOfQuestions)
            {
                Console.WriteLine(Question);

                for (int i = 0; i < Question.AnswerList.Length; i++)
                {
                    Console.WriteLine(Question.AnswerList[i]);
                }
                Console.WriteLine("------------------------------------");
                int userAnswerId;
                    do
                    {
                        Console.WriteLine("Enter Number Of Your Answer");
                    } while (!int.TryParse(Console.ReadLine(), out userAnswerId) || (userAnswerId < 1 || userAnswerId > 3));
                    Question.UserAnswer.AnswerId = userAnswerId;
                    Question.UserAnswer.AnswerText = Question.AnswerList[userAnswerId - 1].AnswerText;
                    Console.WriteLine("----------------------");
                Console.Clear();
                
            }
            Console.WriteLine("Right Answers");
            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                Console.WriteLine($"Right Answer of question {i + 1}: {ListOfQuestions[i].RightAnswer.AnswerText}");
            }


        }
    }
}
