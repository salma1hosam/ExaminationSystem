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
        public PracticalExam():base()
        {
            MCQ = new MCQuestion[NumberOfQuestions];
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                //for (int j = 0; j < MCQ?.Length; j++)
                Console.WriteLine($"Please Enter the Details of Question Number({i+1}):");
                MCQ[i] = new MCQuestion();
            }
        }
        #endregion

        #region Methods
        public override void ShowExam()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
