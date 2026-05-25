using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal abstract class Question
    {
        #region Attributes
        private string header;
        private string body;
        private int mark;
        private Answers[] answerList;
        private Answers correctAnswer;
        #endregion

        #region Properties
        public virtual string Header
        {
            get => header;
            set
            {
                header = value;
                Console.WriteLine(value);
            }
        }

        public string Body
        {
            get => body;
            set
            {
                do
                {
                    Console.WriteLine("Please Enter the Body of the Question:");
                    body = Console.ReadLine();
                } while (body is null);
            }
        }

        public int Mark
        {
            get => mark;
            set
            {
                bool isMark;
                do
                {
                    Console.Write("Please Enter the Mark of the Question: ");
                    isMark = int.TryParse(Console.ReadLine(), out mark);
                } while (!isMark || mark < 0);
            }
        }
        public virtual Answers[] AnswerList { get => answerList; set => answerList = value; }
        public virtual Answers CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

        #endregion

        #region Constructors
        protected Question(string header)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        #endregion

    }
}
