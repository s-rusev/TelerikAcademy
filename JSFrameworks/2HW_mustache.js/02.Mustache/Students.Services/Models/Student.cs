using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.Models
{
    [DataContract(Name = "student")]
    public class Student
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }

        [DataMember(Name = "fullname")]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }


        public Student()
        {
            this.Marks = new List<Mark>();
        }
    }
}