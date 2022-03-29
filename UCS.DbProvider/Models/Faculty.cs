namespace UCS.DbProvider.Models;
using System.Collections.Generic;

public class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<Group> Groups { get; set; }
}