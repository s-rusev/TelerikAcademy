using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SchoolHierarchy
{
    class Student : Human, ICommentable
    {
        #region private fields
        private readonly int uniqueNumberInClass;
        private readonly List<String> comments = new List<string>();
        private static readonly List<int> numbersForStudents = new List<int>();

        #endregion

        #region constructors
        public Student(string name, int numberInClass)
            : base(name)
        {
            if (numbersForStudents.Contains(numberInClass))
            {
                throw new ArgumentException("The number of the student must be unique!");
            }
            this.uniqueNumberInClass = numberInClass;
            numbersForStudents.Add(numberInClass);
        }
        #endregion

        #region properties
        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }


        public int UniqueNumberInClass
        {
            get
            {
                return this.uniqueNumberInClass;
            }
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return string.Format("Name: {0}, number in class: {1}", base.Name, uniqueNumberInClass);
        }
        #endregion
    }
}
