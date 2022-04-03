using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models;

public class Subject
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<Group> Groups { get; set; }
    //[JsonIgnore]
    //[IgnoreDataMember] 
    public virtual ICollection<Chapter> Chapters { get; set; }
}