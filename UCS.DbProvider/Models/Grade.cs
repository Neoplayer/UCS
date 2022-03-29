using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCS.DbProvider.Models;

public class Grade
{
    public int Id { get; set; }

    public int GradeNumber { get; set; }    // TODO rename
    public string Description { get; set; }

    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<Question> Questions { get; set; }
    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<SessionAnswer> SessionAnswers { get; set; }
}