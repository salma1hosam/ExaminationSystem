using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class MCQuestion : Question
    {

        #region Properties
     
        public override Answers[] AnswerList 
        { 
            get => base.AnswerList;
            set
            {
                base.AnswerList = new Answers[3];
                Console.WriteLine("The Choices of the Question:");
                for (int i = 0; i < 3; i++)
                {
                    string text;
                    do
                    {
                        Console.Write($"Please Enter the Choice Number {i + 1}: ");
                        text = Console.ReadLine();
                    } while (text is null);

                    if (base.AnswerList?.Length > 0)
                        base.AnswerList[i] = new Answers(i + 1, text);
                }
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
                    Console.WriteLine("Please Specify the Correct Choice of the Question:");
                    isCorrectAnswer = int.TryParse(Console.ReadLine(), out correct);
                } while (!isCorrectAnswer || correct < 0 || correct > AnswerList?.Length);

                if (base.AnswerList?.Length > 0)
                    base.CorrectAnswer = base.AnswerList[correct - 1];
                else
                    Console.WriteLine("AnswerList is Not Initialized");

                Console.Clear();
            }
        }
        #endregion

        #region Constructors
        public MCQuestion(string header, string body, int mark, Answers[] answerList, Answers correctAnswer)
            : base("Choose One Answer Question", body, mark)
        {
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }
        public MCQuestion():base("Choose One Answer Question")
        {
            AnswerList = AnswerList;
            CorrectAnswer = CorrectAnswer;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Header}           Mark({Mark})\n{Body}";
        }
        #endregion
    }
}
