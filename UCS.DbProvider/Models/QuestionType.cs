using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models;

public class QuestionType
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<TopicRule> TopicRules { get; set; }
}