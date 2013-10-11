using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SchoolHierarchy
{
    class Disciplines : ICommentable
    {
        #region private fields
        private string nameDiscipline;
        private uint numberOfLectures;
        private uint numberOfExercises;
        private readonly List<string> comments = new List<string>();

        #endregion

        #region constructors
        public Disciplines(string nameDiscipline, uint numberOfLectures, uint numberOfExercises)
        {
            this.nameDiscipline = nameDiscipline;
            this.numberOfExercises = numberOfExercises;
            this.numberOfLectures = numberOfLectures;
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

        public uint NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                this.numberOfLectures = value;
            }
        }

        public uint NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                this.numberOfExercises = value;
            }
        }

        public string NameDiscipline
        {
            get
            {
                return this.nameDiscipline;
            }
            set
            {
                this.nameDiscipline = value;
            }
        }
        #endregion

        #region methods
        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return string.Format("nameDiscipline: {0}, numberOfLectures: {1}, numberOfExercises: {2}", nameDiscipline, numberOfLectures, numberOfExercises);
        }
        #endregion
    }
}
