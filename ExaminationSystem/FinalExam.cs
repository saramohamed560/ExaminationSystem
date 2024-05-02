using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class FinalExam : Exam
    {
        public FinalExam(int time,int numberOfQuestions):base(time,numberOfQuestions)
        {
            
        }
        public override void CreateListOfQuestions()
        {
            ListOfQuestions = new Question[NumberOfQuetions];
            for (int i = 0;i < NumberOfQuetions;i++)
            {
                int choice;
                do
                {
                    Console.WriteLine("Enter 1 for MCQ or 2 for T/F Question");
                }while(!int.TryParse(Console.ReadLine(), out choice)||choice <1 || choice>2);
                Console.Clear();
                if(choice == 1)
                {
                    ListOfQuestions[i] = new MCQQuestion();
                    ListOfQuestions[i].AddQuestion();
                }
                else if(choice == 2)
                {
                    ListOfQuestions[i] = new TFQuestion();
                    ListOfQuestions[i].AddQuestion();
                }
            }
        }

        public override void ShowExam()
        {
            int TotalMarks = 0, Grade = 0;
            foreach(var Question in ListOfQuestions)
            {
                Console.WriteLine(Question);

                for(int i = 0;i< Question.AnswerList.Length; i++)
                {
                    Console.WriteLine(Question.AnswerList[i]);
                }
                Console.WriteLine("------------------------------------");
                int userAnswerId;
                if (Question.Header == "MCQ Question")
                {
                    do
                    {
                        Console.WriteLine("Enter Number Of Your Answer");
                    } while (!int.TryParse(Console.ReadLine(), out userAnswerId) || (userAnswerId < 1 || userAnswerId > 3));
                    Question.UserAnswer.AnswerId = userAnswerId;
                    Question.UserAnswer.AnswerText = Question.AnswerList[userAnswerId - 1].AnswerText;
                    Console.WriteLine("----------------------");
                }else if (Question.Header == "True OR False Question")
                {
                    do
                    {
                        Console.WriteLine("Enter Number Of Your Answer");
                    } while (!int.TryParse(Console.ReadLine(), out userAnswerId) || (userAnswerId < 1 || userAnswerId > 2));
                    Question.UserAnswer.AnswerId = userAnswerId;
                    Question.UserAnswer.AnswerText = Question.AnswerList[userAnswerId - 1].AnswerText;
                    Console.WriteLine("----------------------");
                }
                Console.Clear();
                TotalMarks += Question.Marks;
            }
            for(int i = 0; i<ListOfQuestions.Length; i++)
            {
                if (ListOfQuestions[i].RightAnswer.AnswerId == ListOfQuestions[i].UserAnswer.AnswerId)
                {
                    Grade += ListOfQuestions[i].Marks;
                }
                Console.WriteLine($"Question ({i+1}): {ListOfQuestions[i].Body} ");
                Console.WriteLine($"Your Answer: {ListOfQuestions[i].UserAnswer.AnswerText}");
                Console.WriteLine($"Right Answer: {ListOfQuestions[i].RightAnswer.AnswerText}");
            }
            Console.WriteLine($"Your Grade is {Grade}/{TotalMarks}");
        }
    }
}
