using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore
{
    public class Producer
    {
        public string Name { get; set; }

        public ICollection<string> Models { get; set; }

        public Producer(string name, ICollection<string> models)
        {
            this.Name = name;
            this.Models = models;
        }
    }
}