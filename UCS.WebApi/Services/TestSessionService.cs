using UCS.DbProvider;
using UCS.DbProvider.Models;

namespace UCS.WebApi.Services;

public interface ITestSessionService
{
    TestSession? StartSession(User user, Topic topic);
    bool FinishSession(User user);
    TestSession? GetActiveSession(User user);

    bool SendAnswer();
    bool RemoveAnswer();
}

public class TestSessionService : ITestSessionService
{
    public TestSession? StartSession(User user, Topic topic)
    {
        if (GetActiveSession(user) != null)
        {
            return null;
        }

        TestSession session = new TestSession()
        {
            TopicId = topic.Id,
            StartDatetime = DateTime.UtcNow,
            TimeLimitDatetime = DateTime.UtcNow + topic.TimeLimit,
            UserId = user.Id
        };

        using MainContext context = new MainContext();

        context.TestSessions.Add(session);
        context.SaveChanges();

        return session;
    }

    public bool FinishSession(User user)
    {
        var session = GetActiveSession(user);

        if (session == null)
        {
            return false;
        }
        
        session.FinishDatetime = DateTime.UtcNow;
        
        using MainContext context = new MainContext();
        context.TestSessions.Update(session);
        context.SaveChanges();

        return true;
    }

    public TestSession? GetActiveSession(User user)
    {
        using MainContext context = new MainContext();

        var session = context.TestSessions
            .Where(x => x.UserId == user.Id)
            .Where(x => x.TimeLimitDatetime > DateTime.UtcNow)
            .FirstOrDefault(x => x.FinishDatetime != null && x.FinishDatetime > DateTime.UtcNow);

        return session;
    }

    public bool SendAnswer()
    {
        throw new NotImplementedException();
    }

    public bool RemoveAnswer()
    {
        throw new NotImplementedException();
    }
}