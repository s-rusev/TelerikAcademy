using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _01.SchoolHierarchy
{
    class StudentClass : ICommentable
    {
        #region private fields
        private List<Teacher> classTeachers;
        private List<Student> classStudents;
        private readonly string uniqueTextIdentifier;
        private List<String> comments;
        private readonly List<String> textIdentifiersForStudentClass = new List<string>();
        #endregion

        #region constructors
        public StudentClass(List<Student> students, List<Teacher> teachers, string textIdentifier)
        {
            this.classStudents = students;
            this.classTeachers = teachers;
            if (textIdentifiersForStudentClass.Contains(textIdentifier))
            {
                throw new ArgumentException("String identifier for class must be unique!");
            }
            this.uniqueTextIdentifier = textIdentifier;
        }
        #endregion

        #region properties
        public List<Student> ClassStudents
        {
            get
            {
                return this.classStudents;
            }
            set
            {
                this.classStudents = value;
            }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
        }
        public string UniqueTextIdentifier
        {
            get
            {
                return this.uniqueTextIdentifier;
            }
        }
        public List<Teacher> ClassTeachers
        {
            get
            {
                return this.classTeachers;
            }
            set
            {
                this.classTeachers = value;
            }
        }
        #endregion

        #region methods
        public void AddComment(string comment)
        {
            if (this.comments == null)
            {
                this.comments = new List<string>();
            }
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Class " + this.uniqueTextIdentifier + " with teachers: ").Append('\n');
            foreach (Teacher teacher in classTeachers)
            {
                sb.Append(teacher.ToString());
            }
            sb.Append("And students: ").Append('\n');
            foreach (Student student in this.classStudents)
            {
                sb.Append(student.ToString());
                sb.Append('\n');
            }
            return sb.ToString();
        }
        #endregion
    }
}
