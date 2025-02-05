using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class FinalExam : Exam
    {
        #region Attributes
        private TrueOrFalseQuestion[] trueOrFalse;
        private MCQuestion[] mCQ;
        private int[] trueORfalseInputAnswers;
        private int[] mcqInputAnswers;
        #endregion

        #region Properties
        public TrueOrFalseQuestion[] TrueOrFalse { get => trueOrFalse; set => trueOrFalse = value; }
        public MCQuestion[] MCQ { get => mCQ; set => mCQ = value; }
        public int[] TrueORfalseInputAnswers { get => trueORfalseInputAnswers; set => trueORfalseInputAnswers = value; }
        public int[] McqInputAnswers { get => mcqInputAnswers; set => mcqInputAnswers = value; }

        #endregion

        #region Constructors
        public FinalExam() : base()
        {
            trueOrFalse = new TrueOrFalseQuestion[NumberOfQuestions];
            mCQ = new MCQuestion[NumberOfQuestions];

            int TrueOrFalseIndex = 0, McqIndex = 0, choice;

            bool isChoice;

            for (int i = 1; i <= NumberOfQuestions; i++)
            {
                do
                {
                    Console.Write($"Please Choose the Type of Question Number({i}) (1 for True OR False || 2 for MCQ) : ");
                    isChoice = int.TryParse(Console.ReadLine(), out choice);
                } while (!isChoice || choice < 1 || choice > 2);

                if (choice == 1)
                {
                    trueOrFalse[TrueOrFalseIndex] = new TrueOrFalseQuestion();
                    TrueOrFalseIndex++;
                }
                else if (choice == 2)
                {
                    mCQ[McqIndex] = new MCQuestion();
                    McqIndex++;
                }
                else
                    Console.WriteLine("Invalid Choice");
            }

            Array.Resize(ref trueOrFalse, TrueOrFalseIndex);
            Array.Resize(ref mCQ, McqIndex);

        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            //int trueOrFalseAnswer;

            //int[] trueORfalseInputAnswers = new int[TrueOrFalse.Length];

            trueORfalseInputAnswers = new int[trueOrFalse.Length];

            if (trueOrFalse?.Length > 0)
            {
                
                bool isTFAnswer;

                for (int i = 0; i < trueOrFalse.Length; i++)
                {
                    ///Console.WriteLine($"{TrueOrFalse[i].Header}           Mark({TrueOrFalse[i].Mark})");
                    ///Console.WriteLine($"{TrueOrFalse[i].Body}\n1. True         2. False");


                    Console.WriteLine(trueOrFalse[i]);

                    if (trueOrFalse[i]?.AnswerList.Length > 0)
                        for (int j = 0; j < trueOrFalse[i].AnswerList.Length; j++)
                            Console.Write($"{trueOrFalse[i].AnswerList[j].Id}. {trueOrFalse[i].AnswerList[j].Text}        ");

                    Console.WriteLine("\n--------------------------------------------------");

                    isTFAnswer = int.TryParse(Console.ReadLine(), out trueORfalseInputAnswers[i]);

                    while (!isTFAnswer || trueORfalseInputAnswers[i] < 0 || trueORfalseInputAnswers[i] > trueOrFalse[i].AnswerList.Length)
                    {
                        Console.WriteLine("Invalid Choice!\nPlease Choose one from the Previous Valid choices");
                        isTFAnswer = int.TryParse(Console.ReadLine(), out trueORfalseInputAnswers[i]);

                    }



                    Console.WriteLine("=====================================================\n");
                }
            }


            //int McqAnswer = 0;

            //int[] mcqInputAnswers = new int[MCQ.Length];

            mcqInputAnswers = new int[mCQ.Length];

            if (mCQ?.Length > 0)
            {
                bool isMCQAnswer;
                for (int i = 0; i < mCQ.Length; i++)
                {
                    ///Console.WriteLine($"{MCQ[i].Header}           Mark({MCQ[i].Mark})");
                    ///Console.WriteLine($"{MCQ[i].Body}");


                    Console.WriteLine(mCQ[i]);

                    if (mCQ[i]?.AnswerList.Length > 0)
                        for (int j = 0; j < mCQ[i].AnswerList.Length; j++)
                            Console.Write($"{mCQ[i].AnswerList[j].Id}. {mCQ[i].AnswerList[j].Text}        ");

                    Console.WriteLine("\n--------------------------------------------------");

                    isMCQAnswer = int.TryParse(Console.ReadLine(), out mcqInputAnswers[i]);
                    while (!isMCQAnswer || mcqInputAnswers[i] < 0 || mcqInputAnswers[i] > mCQ[i].AnswerList.Length)
                    {
                        Console.WriteLine("Invalid Choice!\nPlease Choose one from the Previous Valid choices");
                        isMCQAnswer = int.TryParse(Console.ReadLine(), out mcqInputAnswers[i]);

                    }
                    Console.WriteLine("=====================================================\n");
                }
            }

            Console.Clear();

            ShowQuestionsAndAnswers();

            ShowGrade();
        }

        private void ShowQuestionsAndAnswers()
        {
            if (trueOrFalse?.Length > 0 || mCQ?.Length > 0)
            {
                Console.WriteLine("Your Answers:");

                for (int i = 0; i < trueOrFalse?.Length; i++)
                    Console.WriteLine($"Q{i + 1}) {trueOrFalse[i].Body} : {trueOrFalse[i].AnswerList[trueORfalseInputAnswers[i] - 1].Text}");

                for (int j = 0; j < mCQ?.Length; j++)
                    Console.WriteLine($"Q{(trueOrFalse.Length) + j + 1}) {mCQ[j].Body} : {mCQ[j].AnswerList[mcqInputAnswers[j] - 1].Text}");
            }
        }

        private void ShowGrade()
        {
            int totalMarks = 0;
            int qCounter = 0;

            if (trueOrFalse?.Length > 0)
            {
                for (int i = 0; i < trueOrFalse.Length; i++)
                { 
                    totalMarks += trueOrFalse[i].Mark;
                    if (trueORfalseInputAnswers[i] == trueOrFalse[i].CorrectAnswer.Id)
                        qCounter += trueOrFalse[i].Mark;
                }

            }

            if (mCQ?.Length > 0)
            {
                for (int j = 0; j < mCQ.Length; j++)
                { 
                    totalMarks += mCQ[j].Mark;
                    if (mcqInputAnswers[j] == mCQ[j].CorrectAnswer.Id)
                        qCounter += mCQ[j].Mark;
                }
            }

            Console.WriteLine($"Your Exam Grade is {qCounter} from {totalMarks}");
        }
        #endregion
    }
}
