using System;

namespace UCS.DbProvider.Models;

public class SessionAnswer
{
    public int Id { get; set; }
    
    public int TestSessionId { get; set; }
    public TestSession TestSession { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int? GradeId { get; set; }
    public Grade Grade { get; set; }
    public Guid? ImageId { get; set; }
    public Image Image { get; set; }

    public string Comments { get; set; }
}