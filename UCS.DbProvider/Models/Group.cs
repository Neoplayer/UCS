namespace UCS.DbProvider.Models;
using System.Collections.Generic;

public class Group
{
    public int Id { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public string Name { get; set; }

    public IEnumerable<Group> Groups { get; set; }
    public IEnumerable<Subject> Subjects { get; set; }
}