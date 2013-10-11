using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _01.SchoolHierarchy
{
    class Teacher : Human, ICommentable
    {
        #region private fields
        private List<Disciplines> disciplinesTeached;
        private List<string> comments;
        #endregion

        #region constructors
        public Teacher(string name, List<Disciplines> disciplines)
            : base(name) //calls the human constructor with name parameter
        {
            this.disciplinesTeached = disciplines;
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

        public List<Disciplines> DisciplinesTeached
        {
            get
            {
                return this.disciplinesTeached;
            }
            set
            {
                this.disciplinesTeached = value;
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

        public void AddDiscipline(Disciplines discipline)
        {
            if (discipline == null)
            {
                throw new ArgumentNullException("Discipline doesn't exist.");
            }
            this.disciplinesTeached.Add(discipline);
        }

        public void RemoveDiscipline(Disciplines discipline)
        {
            if (discipline == null)
            {
                throw new ArgumentNullException("Cannot remove empty entry for discipline.");
            }
            this.disciplinesTeached.Remove(discipline);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Teacher with name " + base.Name).Append('\n').Append("Teaches disciplines:").Append('\n');
            foreach (var discipline in disciplinesTeached)
            {
                sb.Append(discipline.ToString()).Append('\n');
            }
            return sb.ToString();
        }
        #endregion
    }
}
