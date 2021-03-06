using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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

    public int? Result { get; set; }
    public string? Comment { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<SessionAnswer> Answers { get; set; }
}