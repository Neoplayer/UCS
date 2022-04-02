using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCS.DbProvider.Models;

public class TestSession
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public int TopicId { get; set; }
    public Topic Topic { get; set; }

    public DateTime StartDatetime { get; set; }
    public DateTime? FinishDatetime { get; set; }
    public DateTime TimeLimitDatetime { get; set; }

    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<SessionAnswer> Answers { get; set; }
}