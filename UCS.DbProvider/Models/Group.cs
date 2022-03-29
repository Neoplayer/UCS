using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCS.DbProvider.Models;

public class Group
{
    public int Id { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<User> Users { get; set; }
    [JsonIgnore]
    [IgnoreDataMember] 
    public ICollection<Subject> Subjects { get; set; }
}