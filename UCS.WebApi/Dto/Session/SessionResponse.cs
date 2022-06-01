using UCS.DbProvider.Models;

namespace UCS.WebApi.Dto.Session
{
    public class SessionResponse : ResponseBase
    {
        public int Id { get; set; }
        public TopicResponse TopicInfo { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? FinishDatetime { get; set; }
        public DateTime TimeLimit { get; set; }
        public TimeSpan TimeLeft { get; set; }

        public User User { get; set; }

        public List<QuestionResponse> Questions { get; set; }

        public int? Result { get; set; }
        public string? Comment { get; set; }
    }
}