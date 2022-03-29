using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Chapter
{
    public int Id { get; set; }
    
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public string Name { get; set; }

    public IEnumerable<Topic> Topics { get; set; }
}