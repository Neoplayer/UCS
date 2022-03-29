namespace UCS.DbProvider.Models;
using System.Collections.Generic;

public class Grade
{
    public int Id { get; set; }

    public int GradeNumber { get; set; }    // TODO rename
    public string Description { get; set; }

    public IEnumerable<Question> Questions { get; set; }
    public IEnumerable<SessionAnswer> SessionAnswers { get; set; }
}