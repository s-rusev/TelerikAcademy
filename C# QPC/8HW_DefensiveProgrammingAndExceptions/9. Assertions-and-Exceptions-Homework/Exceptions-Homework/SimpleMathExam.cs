using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    private const int AllProblemsCount = 10;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved > AllProblemsCount || problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException(
                "problemsSolved",
                string.Format("problemsSolved must be in the range between {0} and {1}.", 0, AllProblemsCount));
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved > AllProblemsCount || this.ProblemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException(
                "problemsSolved",
                string.Format("problemsSolved must be in the range between {0} and {1}.", 0, AllProblemsCount));
        }
        switch (ProblemsSolved)
        {
            case 0:
                {
                    return new MathExamResult(2, "Bad result: nothing done.");
                }
            case 1:
                {
                    return new MathExamResult(4, "Average result: 1 problem solved.");
                }
            case 2:
                {
                    return new MathExamResult(6, "High result: 2 problems solved.");
                }
        }
        throw new ArgumentOutOfRangeException("Invalid number of problems solved.");
    }
}
