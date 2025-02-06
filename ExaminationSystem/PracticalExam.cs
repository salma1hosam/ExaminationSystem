using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class PracticalExam : Exam
    {
        #region Properties
        public MCQuestion[] MCQ { get; set; }
        #endregion

        #region Constructors
        public PracticalExam() : base()
        {
            MCQ = new MCQuestion[NumberOfQuestions];
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Please Enter the Details of Question Number({i + 1}):");
                MCQ[i] = new MCQuestion();
            }
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            if (MCQ?.Length > 0)
            {
                int[] McqAnswer = new int[MCQ.Length];

                for (int i = 0; i < MCQ.Length; i++)
                {
                    bool isMCQAnswer;

                    Console.WriteLine(MCQ[i]);

                    if (MCQ[i]?.AnswerList.Length > 0)
                        for (int j = 0; j < MCQ[i].AnswerList.Length; j++)
                            Console.Write($"{MCQ[i].AnswerList[j].Id}. {MCQ[i].AnswerList[j].Text}        ");

                    Console.WriteLine("\n--------------------------------------------------");

                    isMCQAnswer = int.TryParse(Console.ReadLine(), out McqAnswer[i]);
                    while (!isMCQAnswer || McqAnswer[i] < 1 || McqAnswer[i] > MCQ[i].AnswerList.Length)
                    {
                        Console.WriteLine("Invalid Choice!\nPlease Choose one from the Previous Valid choices");
                        isMCQAnswer = int.TryParse(Console.ReadLine(), out McqAnswer[i]);
                    }
                    Console.WriteLine("=====================================================\n");
                }

                Console.Clear();

                ShowCorrectAnswers();
            }
        }


        private void ShowCorrectAnswers()
        {
            Console.WriteLine("The Correct Answers of:");
            if (MCQ?.Length > 0)
                for (int i = 0; i < MCQ.Length; i++)
                    Console.WriteLine($"Q{i + 1}) {MCQ[i].CorrectAnswer.Text}");
        }

        #endregion
    }
}
