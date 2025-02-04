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
        private double mark;

        private Answers[] answerList;
        private Answers correctAnswer;
        #endregion

        #region Properties
        ///public string Header { get; set; }
        ///public string Body { get; set; }
        ///public double Mark { get; set; }
        ///public Answers []AnswersList { get; set; }
        ///public int CorrectAnswer { get; set; }

        //public virtual string Header { get; set; }

        public virtual string Header
        {
            get { return header; }
            set 
            { 
                header = value;
                Console.WriteLine(value);
            }
        }


        public string Body
        {
            get { return body; }
            set 
            {
                do
                {
                    Console.WriteLine("Please Enter the Body of the Question:");
                    body = Console.ReadLine() ?? " ";
                } while (body is null);
            }
        }


        public double Mark
        {
            get { return mark; }
            set 
            {
                bool isMark;
                do
                {
                    Console.Write("Please Enter the Mark of the Question: ");
                    isMark = double.TryParse(Console.ReadLine(), out mark); 
                } while (!isMark);
            }
        }

        public virtual Answers[] AnswerList
        {
            get { return answerList; }
            set { answerList = value; }
        }

        public virtual Answers CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        ///public virtual Answers[] AnswerList { get; set; }
        ///public virtual Answers CorrectAnswer { get; set; }

        #endregion

        #region Constructors
        ///protected Question(string header, string body, double mark, Answers[] answersList, int correctAnswer)
        ///{
        ///    Header = header;
        ///    Body = body;
        ///    Mark = mark;
        ///    AnswersList = answersList;
        ///    CorrectAnswer = correctAnswer;
        ///}
        protected Question(string header, string body, double mark/*, Answers[] answerList, Answers correctAnswer*/)
        {
            Header = header;
            Body = body;
            Mark = mark;
            //AnswerList = answerList;
            //CorrectAnswer = correctAnswer;
        }
        protected Question(string header)
        {
            Header = header;
            Body = Body;
            Mark = Mark;
        }


        #endregion

        #region Methods

        #endregion
    }
}
