using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models;

public class Grade
{
    public int Id { get; set; }

    public int GradeNumber { get; set; }    // TODO rename
    public string Description { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<Question> Questions { get; set; }
    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<SessionAnswer> SessionAnswers { get; set; }
}