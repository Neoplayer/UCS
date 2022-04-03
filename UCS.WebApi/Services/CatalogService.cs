using UCS.DbProvider.Models;
using Microsoft.EntityFrameworkCore;
using UCS.DbProvider;
using UCS.WebApi.Dto;

namespace UCS.WebApi.Services;

public interface ICatalogService
{
    ICollection<Subject>? GetUserDataSubjectsByUser(User user);
    GetTopicResponse? GetTopic(int topicId);
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
    
    public GetTopicResponse? GetTopic(int topicId)
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

        return new GetTopicResponse()
        {
            TopicName = topic.Name,
            CharapterName = topic.Chapter.Name,
            SubjectName = topic.Chapter.Subject.Name,
            TimeLimit = topic.TimeLimit,
            QuestionsCount = topic.TopicRules.Sum(x => x.QuestionsCount)
        };
    }
}