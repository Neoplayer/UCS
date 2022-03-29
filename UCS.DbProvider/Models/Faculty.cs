using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<Group> Groups { get; set; }
}