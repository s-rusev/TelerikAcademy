using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade can't be negative number.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "Minimal grade can't be negative number.");
        }

        if (maxGrade < 0)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "Maximal grade can't be negative number.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "Maximal grade can't be less than minimal grade.");
        }

        if (grade < minGrade || grade > maxGrade)
        {
            throw new ArgumentOutOfRangeException("grade", 
                string.Format("Grade must be between {0} and {1}", minGrade, maxGrade));
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentException("Comments can't be null or empty space", "comments");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
