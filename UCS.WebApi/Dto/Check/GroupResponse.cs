using UCS.DbProvider.Models;

namespace UCS.WebApi.Dto.Check;

public class GroupResponse : ResponseBase
{
    public string Name { get; set; }
    public int StudentsCount => Users.Count;
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}