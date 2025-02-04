using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class TrueOrFalseQuestion : Question
    {
        #region Properties

        public override Answers[] AnswerList 
        {
            get => base.AnswerList;
            set
            {
                base.AnswerList =
                    [
                    new Answers(1, "True"),
                    new Answers(2, "False")
                    ];
            }
        }

        public override Answers CorrectAnswer 
        { 
            get => base.CorrectAnswer;
            set
            {
                bool isCorrectAnswer;
                int correct;
                do
                {
                    Console.WriteLine("Please Enter the Right Answer of the Question (1 for True and 2 for False)");
                    isCorrectAnswer = int.TryParse(Console.ReadLine(), out correct);
                } while (!isCorrectAnswer || correct < 1 || correct > 2);

                if (base.AnswerList?.Length > 0)
                    base.CorrectAnswer = base.AnswerList[correct - 1];
                else
                    Console.WriteLine("AnswerList is Not Initialized");
                Console.Clear();
            }
        }

        #endregion


        #region Constructors
        public TrueOrFalseQuestion(string header, string body, double mark, Answers[] answerList, Answers correctAnswer) :
            base("True | False Question", body, mark)
        {
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }
        public TrueOrFalseQuestion():base("True | False Question")
        {
            AnswerList = AnswerList;
            CorrectAnswer = CorrectAnswer;
        }
        #endregion


    }
}
