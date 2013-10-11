using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CollectionCountAttribute : ValidationAttribute
    {
        private readonly int count;

        public CollectionCountAttribute(int count)
        {
            this.count = count;
        }

        public override bool IsValid(object value)
        {
            var input = value as ICollection<object>;
            if (input.Count > this.count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
