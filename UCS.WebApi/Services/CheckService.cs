using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto.Check;
using UCS.WebApi.Models;

namespace UCS.WebApi.Services;


public interface ICheckService
{
    ICollection<Group> GetGroups(User user);
    ICollection<TestSession> GetTestsToCheck(int userId);
    bool SetTestResult(int sessionId, int result, string comment);
    ICollection<TestSession> GetArchive(int userId);
    ICollection<TestSession> GetCheckedTests(int userId);
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

    public bool SetTestResult(int sessionId, int result, string comment)
    {
        using MainContext context = new MainContext();

        var session = context.TestSessions.FirstOrDefault(x => x.Id == sessionId);
       
        if(session == null)
        {
            return false;
        }

        session.Result = result;
        session.Comment = comment;

        context.SaveChanges();
        return true;
    }
    
    public ICollection<TestSession> GetTestsToCheck(int userId)
    {
        using MainContext context = new MainContext();

        var groupsIds = context.Users
                        .Include(x => x.Groups)
                        .FirstOrDefault(x => x.Id == userId)
                        ?.Groups
                        .Select(x => x.Id);
        
        var sessions = context.TestSessions
            .Include(x => x.Answers)
            .ThenInclude(x => x.Question)
            .Include(x => x.User)
            .ThenInclude(x => x.Groups)
            .Where(x => x.User.Groups.Count == 1)
            .Where(x => (groupsIds ?? Array.Empty<int>()).Contains(x.User.Groups.FirstOrDefault()!.Id))
            .Where(x => x.Result == null)
            .ToList();

        return sessions;
    }

    public ICollection<TestSession> GetArchive(int userId)
    {
        using MainContext context = new MainContext();

        var groupsIds = context.Users
                        .Include(x => x.Groups)
                        .FirstOrDefault(x => x.Id == userId)
                        ?.Groups
                        .Select(x => x.Id);

        var sessions = context.TestSessions
            .Include(x => x.Answers)
            .ThenInclude(x => x.Question)
            .Include(x => x.User)
            .ThenInclude(x => x.Groups)
            .Where(x => x.User.Groups.Count == 1)
            .Where(x => (groupsIds ?? Array.Empty<int>()).Contains(x.User.Groups.FirstOrDefault()!.Id))
            .Where(x => x.Result != null)
            .ToList();

        return sessions;
    }

    public ICollection<TestSession> GetCheckedTests(int userId)
    {
        using MainContext context = new MainContext();

        var sessions = context.TestSessions
                                .Include(x => x.Answers)
                                .ThenInclude(x => x.Question)
                                .Include(x => x.User)
                                .ThenInclude(x => x.Groups)
                                .Where(x => x.UserId == userId)
                                .Where(x => x.Result != null)
                                .ToList();

        return sessions;
    }
}