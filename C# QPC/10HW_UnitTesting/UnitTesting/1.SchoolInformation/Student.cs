using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SchoolInformation
{
    public class Student
    {
        private string name;
        private uint uniqueNumber;

        public Student(string name, uint uniqueNumber)
        {
            this.Name = name;
            if (School.StudentNumbers.Contains(uniqueNumber))
            {
                throw new InvalidOperationException("Cannot create student with this number! It's already taken!");
            }
            School.StudentNumbers.Add(uniqueNumber);

            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }
                if (value == String.Empty)
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public uint UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Unique student number must be between 10000-99999!");
                }
                this.uniqueNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, uniqueNumber: {1}", name, uniqueNumber);
        }

    }
}
