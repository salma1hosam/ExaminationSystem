using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Subject
    {
        #region Attributes
        //private Exam exam;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }

        ///public Exam Exam
        ///{
        ///    get { return exam; }
        ///    set 
        ///    {
        ///        bool isChosen;
        ///        int chosen;
        ///        do
        ///        {
        ///            Console.Write("Please Enter the Type of the Exam you want to create (1 for Practical and 2 for Final): ");
        ///            isChosen = int.TryParse(Console.ReadLine(), out chosen); 
        ///        } while (!isChosen);
        ///        if (chosen == 1)
        ///            exam = new PracticalExam();
        ///        else if(chosen == 2)
        ///            exam = new FinalExam();
        ///        else
        ///            Console.WriteLine("Invalid Choice");
        ///    }
        ///}

        #endregion

        #region Constructors
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        public void CreateExam()
        {
            bool isChosen;
            int chosen;
            do
            {
                Console.Write("Please Enter the Type of the Exam you want to create (1 for Practical and 2 for Final): ");
                isChosen = int.TryParse(Console.ReadLine(), out chosen);
            } while (!isChosen || chosen < 1 || chosen > 2);

            if (chosen == 1)
                Exam = new PracticalExam();
            else if (chosen == 2)
                Exam = new FinalExam();
            else
                Console.WriteLine("Invalid Choice");
        } 
        #endregion
    }
}
