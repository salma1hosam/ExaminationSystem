using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Answers
    {
        #region Properties
        public int Id { get; set; }
        public string Text { get; set; }
        #endregion

        #region Constructors
        public Answers(int id, string text)
        {
            Id = id;
            Text = text;
        }
        #endregion
    }
}
