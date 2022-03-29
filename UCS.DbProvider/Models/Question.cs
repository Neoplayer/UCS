namespace UCS.DbProvider.Models;
using System.Collections.Generic;

public class Question
{
    public int Id { get; set; }

    public int TopicId { get; set; }
    public Topic Topic { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; }
    public int QuestionThemeId { get; set; }
    public QuestionTheme QuestionTheme { get; set; }

    public string Body { get; set; }
    public bool Active { get; set; }

    public IEnumerable<Grade> Grades { get; set; }
    public IEnumerable<SessionAnswer> SessionAnswers { get; set; }
}