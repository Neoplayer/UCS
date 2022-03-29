using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Subject
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public ICollection<Group> Groups { get; set; }
    [JsonIgnore]
    public ICollection<Chapter> Chapters { get; set; }
}