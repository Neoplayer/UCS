using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;
using UCS.DbProvider.Models;

namespace UCS.WebApi.Services;

public interface ITestSessionService
{
    TestSession? StartSession(User user, int topicId);
    bool FinishSession(User user);
    TestSession? GetActiveSession(User user);

    bool SendAnswer(User user, int questionId, byte[] image);
    bool RemoveAnswer(User user, int questionId);
}

public class TestSessionService : ITestSessionService
{
    public TestSession? StartSession(User user, int topicId)
    {
        if (GetActiveSession(user) != null)
        {
            return null;
        }

        using MainContext context = new MainContext();

        var topic = context.Topics.FirstOrDefault(x => x.Id == topicId);

        TestSession session = new TestSession()
        {
            TopicId = topicId,
            StartDatetime = DateTime.UtcNow,
            TimeLimitDatetime = DateTime.UtcNow + (topic?.TimeLimit ?? TimeSpan.Zero),
            UserId = user.Id
        };


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
            .FirstOrDefault(x => (x.TimeLimitDatetime > DateTime.UtcNow) && ((x.FinishDatetime ?? x.TimeLimitDatetime) > DateTime.UtcNow));

        return session;
    }

    public bool SendAnswer(User user, int questionId, byte[] image)
    {
        using MainContext context = new MainContext();

        var session = GetActiveSession(user);

        if (session == null)
        {
            return false;
        }

        var answerInDb =
            context.SessionAnswers.FirstOrDefault(x => x.TestSessionId == session.Id && x.QuestionId == questionId);

        if (answerInDb != null)
        {
            context.SessionAnswers.Remove(answerInDb);
        }

        var imageDb = new Image()
        {
            Id = Guid.NewGuid(),
            ImageBytes = image,
            Size = image.Length,
            UploadImageDateTime = DateTime.UtcNow
        };

        var sessionAnswer = new SessionAnswer()
        {
            QuestionId = questionId,
            Image = imageDb,
            GradeId = questionId,
            TestSessionId = session.Id
        };

        context.SessionAnswers.Add(sessionAnswer);
        context.SaveChanges();

        return true;
    }

    public bool RemoveAnswer(User user, int questionId)
    {
        using MainContext context = new MainContext();

        var session = GetActiveSession(user);

        if (session == null)
        {
            return false;
        }

        var answer = context.SessionAnswers.Include(x => x.Image).FirstOrDefault(x => x.TestSessionId == session.Id && x.QuestionId == questionId);

        if (answer != null)
        {
            context.SessionAnswers.Remove(answer);

            context.SaveChanges();
        }

        return true;
    }
}