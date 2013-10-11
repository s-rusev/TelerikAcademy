using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("Score can't be negative number.");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        int minScoreLimit = 0;
        int maxScoreLimit = 100;
        if (Score < minScoreLimit || Score > maxScoreLimit)
        {
            throw new ArgumentOutOfRangeException(String.Format("Score must be between {0} and {1}.", minScoreLimit, maxScoreLimit));
        }
        else
        {
            ExamResult examResult = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            return examResult;
        }
    }
}
