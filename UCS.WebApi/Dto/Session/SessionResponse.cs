namespace UCS.WebApi.Dto.Session
{
    public class SessionResponse : ResponseBase
    {
        public TopicResponse TopicInfo { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime TimeLimit { get; set; }
        public TimeSpan TimeLeft { get; set; }

        public List<QuestionResponse> Questions { get; set; }
    }
}