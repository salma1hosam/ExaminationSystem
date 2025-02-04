using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class FinalExam : Exam
    {
        #region Properties
        public TrueOrFalseQuestion[] TrueOrFalse { get; set; }
        public MCQuestion[] MCQ { get; set; } 
        #endregion

        #region Constructors
        public FinalExam() : base()
        {
            TrueOrFalse = new TrueOrFalseQuestion[NumberOfQuestions];
            MCQ = new MCQuestion[NumberOfQuestions];

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
                    TrueOrFalse[TrueOrFalseIndex] = new TrueOrFalseQuestion();
                    TrueOrFalseIndex++;
                }
                else if (choice == 2)
                {
                    MCQ[McqIndex] = new MCQuestion();
                    McqIndex++;
                }
                else
                    Console.WriteLine("Invalid Choice");
            }
            //TrueOrFalseQuestion[] trueorfalse = TrueOrFalse;
            //MCQuestion[] mcq = MCQ;

            //Array.Resize(ref trueorfalse, TrueOrFalseIndex);
            //Array.Resize(ref mcq, McqIndex);

            //clone
        } 
        #endregion

        #region Methods
        public override void ShowExam()
        {
            if(TrueOrFalse?.Length > 0)
            {
                for (int i = 0; i < TrueOrFalse.Length; i++)
                {
                    Console.WriteLine($"{TrueOrFalse[i].Header}           Mark({TrueOrFalse[i].Mark})");
                    Console.WriteLine($"{TrueOrFalse[i].Body}\n1. True         2. False");
                    Console.WriteLine("--------------------------------------------------");
                    int trueOrFalseAnswer;
                    int.TryParse(Console.ReadLine(), out trueOrFalseAnswer);
                    Console.WriteLine("=====================================================\n");
                }
            }

            if (MCQ?.GetLength(0) > 0)
            {
                for (int i = 0; i < MCQ.GetLength(0); i++)
                {
                    Console.WriteLine($"{MCQ[i].Header}           Mark({MCQ[i].Mark})");
                    Console.WriteLine($"{MCQ[i].Body}\n");

                    if (MCQ[i]?.AnswerList.Length > 0)
                        for (int j = 0; j < MCQ[i].AnswerList.Length; j++)
                            Console.Write($"{j + 1}. {MCQ[i].AnswerList[j]}        ");

                    Console.WriteLine("--------------------------------------------------");
                    int McqAnswer;
                    int.TryParse(Console.ReadLine(), out McqAnswer);
                    Console.WriteLine("=====================================================\n");
                }
            }
        } 
        #endregion
    }
}
