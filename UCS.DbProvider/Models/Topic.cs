using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCS.DbProvider.Models;

public class Topic
{
    public int Id { get; set; }

    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; }

    public string Name { get; set; }
    public TimeSpan TimeLimit { get; set; }

    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<Question> Questions { get; set; }
    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<TestSession> Sessions { get; set; }
}