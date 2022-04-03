namespace UCS.WebApi.Dto;

public class GetTopicResponse
{
    public string TopicName { get; set; }
    public string CharapterName { get; set; }
    public string SubjectName { get; set; }
    public int QuestionsCount { get; set; }
    public TimeSpan TimeLimit { get; set; }
}