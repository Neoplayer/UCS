using UCS.DbProvider.Models;
using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;

namespace UCS.WebApi.Services;

public interface ICatalogService
{
    ICollection<Subject>? GetUserDataSubjectsByUser(User user);
}

public class CatalogService : ICatalogService
{
    public ICollection<Subject>? GetUserDataSubjectsByUser(User user)
    {
        using MainContext context = new MainContext();

        var dbIUser = context.Users
            .Include(x => x.Group)
            .ThenInclude(x => x.Subjects)
            .ThenInclude(x => x.Chapters)
            .ThenInclude(x => x.Topics)
            .FirstOrDefault(x => x.Id == user.Id);

        return dbIUser?.Group.Subjects;
    }
}