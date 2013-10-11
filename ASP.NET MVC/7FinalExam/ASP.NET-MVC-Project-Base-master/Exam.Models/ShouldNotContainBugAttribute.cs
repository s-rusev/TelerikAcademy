using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ShouldNotContainBugAttribute : ValidationAttribute
    {
        private string text;

        public ShouldNotContainBugAttribute(string text)
        {
            this.text = text;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;

            if (valueAsString == null)
            {
                return true;
            }

            bool isValid = !valueAsString.ToLower().Contains(text.ToLower());
            return isValid;
        }
    }
}
