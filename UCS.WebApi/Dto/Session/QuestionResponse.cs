namespace UCS.WebApi.Dto.Session
{
    public class QuestionResponse
    {
        public int QuestionId { get; set; }
        public string Body { get; set; }
        public Guid? QuestionImageId { get; set; }
        public Guid? AnswerImageId { get; set; }
    }
}