using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Question
{
    public int Id { get; set; }

    public int TopicId { get; set; }
    public Topic Topic { get; set; }
    public Guid? ImageId { get; set; }
    public Image Image { get; set; }
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; }
    public int QuestionThemeId { get; set; }
    public QuestionTheme QuestionTheme { get; set; }

    public string Body { get; set; }
    public bool Active { get; set; }

    [JsonIgnore]
    public ICollection<Grade> Grades { get; set; }
    [JsonIgnore]
    public ICollection<SessionAnswer> SessionAnswers { get; set; }
}