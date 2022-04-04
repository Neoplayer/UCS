using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto.Check;
using UCS.WebApi.Models;

namespace UCS.WebApi.Services;


public interface ICheckService
{
    ICollection<Group> GetGroups(User user);
}
public class CheckService : ICheckService
{
    public ICollection<Group> GetGroups(User user)
    {
        using MainContext context = new MainContext();

        var groups = context.Groups
            .Include(x => x.Users)
            .ThenInclude(x => x.Roles)
            .Include(x => x.Subjects)
            .Where(x => x.Users.Any(u => u.Roles.Any(r => r.Id == (int) ERole.Teacher) && u.Id == user.Id));

        return groups.ToList();
    }
}