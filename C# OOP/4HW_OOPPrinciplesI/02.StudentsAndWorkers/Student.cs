using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    public class Student : Human
    {
        #region private fields
        private string grade;
        #endregion

        #region constructors
        public Student(string firstName, string lastName, string grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }
        #endregion

        #region properties
        public string Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return string.Format("{0} {1} with grade: {2}", base.FirstName, base.LastName, grade);
        }
        #endregion
    }
}
