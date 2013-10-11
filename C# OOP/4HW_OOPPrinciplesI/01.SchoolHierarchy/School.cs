using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SchoolHierarchy
{
    class School
    {
        #region private fields
        private List<StudentClass> schoolClasses;
        #endregion

        #region constructors
        public School(List<StudentClass> studentClasses)
        {
            this.schoolClasses = studentClasses;
        }
        #endregion

        #region properties
        public List<StudentClass> SchoolClasses
        {
            get
            {
                return this.schoolClasses;
            }
            set
            {
                this.schoolClasses = value;
            }
        }
        #endregion

        #region methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.schoolClasses.Count == 0)
            {
                Console.WriteLine("No classes in the school!");
            }
            else
            {
                foreach (StudentClass studentClass in schoolClasses)
                {
                    sb.Append(studentClass.ToString());
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
