using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class TFQuestion : Question
    {
        public override string Header => "True OR False Question";

        public TFQuestion()
        {
            AnswerList = new Answer[2];
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
        }

        public override void AddQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine("Please Enter Body Of Question");
            Body = Console.ReadLine();

            int mark;
            do
            {
                Console.WriteLine("Please Enter Mark Of Question");
            } while (!int.TryParse(Console.ReadLine(), out mark) || mark < 1);
            Marks = mark;
            int RightAnswerId;
            do
            {
                Console.WriteLine("Please enter id of Right Answer");
            } while (!int.TryParse(Console.ReadLine(), out RightAnswerId) || RightAnswerId < 1 || RightAnswerId > 3);

            RightAnswer.AnswerId = RightAnswerId;
            RightAnswer.AnswerText = AnswerList[RightAnswerId - 1].AnswerText;

            Console.Clear();
        }
    }
}
