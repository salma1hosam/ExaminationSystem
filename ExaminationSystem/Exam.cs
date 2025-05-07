using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal abstract class Exam
    {
        #region Attributes
        private int time;
        private int numberOfQuestions;
        #endregion

        #region Properties
        public int Time
        {
            get => time;
            set
            {
                bool isTime;
                do
                {
                    Console.Write("Please Enter the Time of the Exam in Minutes: ");
                    isTime = int.TryParse(Console.ReadLine(), out time);
                } while (!isTime || time < 1);
            }
        }


        public int NumberOfQuestions
        {
            get => numberOfQuestions;
            set
            {
                bool isNumber;
                do
                {
                    Console.Write("Please Enter the Number of Questions you wanted to create: ");
                    isNumber = int.TryParse(Console.ReadLine(), out numberOfQuestions);
                    Console.Clear();
                } while (!isNumber || numberOfQuestions < 1);
            }
        }
        #endregion

        #region Constructors
        protected Exam()
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
        }
        #endregion

        #region Methods
        public abstract void ShowExam();
        #endregion
    }
}
