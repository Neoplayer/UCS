using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models;

public class Chapter
{
    public int Id { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    public string Name { get; set; }

    //[JsonIgnore]
    //[IgnoreDataMember] 
    public virtual ICollection<Topic> Topics { get; set; }
}