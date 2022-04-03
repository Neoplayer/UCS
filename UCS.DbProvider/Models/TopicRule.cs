namespace UCS.DbProvider.Models;

public class TopicRule
{
    public int Id { get; set; }

    public int TopicId { get; set; }
    public Topic Topic { get; set; }
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; }
    public int QuestionThemeId { get; set; }
    public QuestionTheme QuestionTheme { get; set; }
    
    public int QuestionsCount { get; set; }
}