using System.Linq;
using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto;

namespace UCS.WebApi.Services;

public interface ICatalogService
{
    ICollection<Subject>? GetUserDataSubjectsByUser(User user);
    TopicResponse? GetTopic(int topicId);
}

public class CatalogService : ICatalogService
{
    public ICollection<Subject>? GetUserDataSubjectsByUser(User user)
    {
        using MainContext context = new MainContext();

        var dbIUser = context.Users
            .Include(x => x.Groups)
            .ThenInclude(x => x.Subjects)
            .ThenInclude(x => x.Chapters)
            .ThenInclude(x => x.Topics)
            .FirstOrDefault(x => x.Id == user.Id);

        return dbIUser?.Groups.SelectMany(x => x.Subjects).ToArray();
    }

    public TopicResponse? GetTopic(int topicId)
    {
        using MainContext context = new MainContext();

        var topic = context.Topics
            .Include(x => x.TopicRules)
            .Include(x => x.Chapter)
            .ThenInclude(x => x.Subject)
            .FirstOrDefault(x => x.Id == topicId);

        if (topic == null)
        {
            return null;
        }

        return new TopicResponse()
        {
            TopicName = topic.Name,
            CharapterName = topic.Chapter.Name,
            SubjectName = topic.Chapter.Subject.Name,
            TimeLimit = topic.TimeLimit,
            QuestionsCount = topic.TopicRules.Sum(x => x.QuestionsCount)
        };
    }
}