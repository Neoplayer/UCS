using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Group
{
    public int Id { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<User> Users { get; set; }
    [JsonIgnore]
    public ICollection<Subject> Subjects { get; set; }
}