using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MathExamResult : ExamResult
{
    public MathExamResult(int grade, string comments)
        : base(grade, 2, 6, comments)
    {
    }
}

