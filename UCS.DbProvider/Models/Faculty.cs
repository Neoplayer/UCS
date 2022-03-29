using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCS.DbProvider.Models;

public class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<Group> Groups { get; set; }
}