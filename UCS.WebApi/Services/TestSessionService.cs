using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto;

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

        var topic = context.Topics.Include(x => x.TopicRules).FirstOrDefault(x => x.Id == topicId);

        var questions = CombineTest(topic);

        TestSession session = new TestSession()
        {
            TopicId = topicId,
            StartDatetime = DateTime.UtcNow,
            TimeLimitDatetime = DateTime.UtcNow + (topic?.TimeLimit ?? TimeSpan.Zero),
            UserId = user.Id,
            Answers = questions.Select(x => new SessionAnswer()
            {
                QuestionId = x.Id
            }).ToList()
        };


        context.TestSessions.Add(session);
        context.SaveChanges();

        session.Answers = context.SessionAnswers.Include(x => x.Question).Where(x => x.TestSessionId == session.Id).ToList();
        
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
            .Include(x => x.Answers)
            .ThenInclude(x => x.Question)
            .Where(x => x.UserId == user.Id)
            .FirstOrDefault(x => (x.TimeLimitDatetime > DateTime.UtcNow) && ((x.FinishDatetime ?? x.TimeLimitDatetime) > DateTime.UtcNow));

        return session;
    }
    
    public ICollection<Question>? CombineTest(Topic topic)
    {
        using MainContext context = new MainContext();

        var questionsList = new List<Question>();
        
        foreach (var rule in topic.TopicRules)
        {
            Random random = new Random(DateTime.Now.Ticks.GetHashCode());

            var questions = context.Questions
                .Where(x => x.QuestionThemeId == rule.QuestionThemeId && x.QuestionTypeId == rule.QuestionTypeId)
                .ToArray();

            for (int i = 0; i < rule.QuestionsCount; i++)
            {
                var number = random.Next(0, questions.Count());

                while (questionsList.Any(x => x.Id == questions[number].Id))
                {
                    number = random.Next(0, questions.Count());
                }
                
                questionsList.Add(questions[number]);
            }
            
        }
        
        return questionsList;
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

        if (answerInDb == null)
        {
            return false;
        }

        var imageDb = new Image()
        {
            Id = Guid.NewGuid(),
            ImageBytes = image,
            Size = image.Length,
            UploadDateTime = DateTime.UtcNow
        };

        answerInDb.Image = imageDb;

        context.SessionAnswers.Update(answerInDb);
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
            answer.ImageId = null;
            
            context.SessionAnswers.Update(answer);
            context.Images.Remove(answer.Image);

            context.SaveChanges();
        }

        return true;
    }
}