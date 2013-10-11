﻿using StudentsDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SchoolModel(School school)
        {
            this.Id = school.Id;
            this.Name = school.Name;
        }
    }
}