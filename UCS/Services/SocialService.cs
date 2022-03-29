using DbProvider;
using DbProvider.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Services
{
    public interface ISocialService
    {
        Chat CreateChat(User user, string name, ChatType type);
        ICollection<Chat> GetChatsByUser(User user);
        ICollection<Chat> GetChatsByUser(User user, ChatType type);
        bool RemoveChat(Chat chat, User user);


        ICollection<Message> GetMessagesByChat(int chatId, int count, int page);
        ICollection<Message> GetLastMessagesByChat(int chatId, int lastMessageId);
        Message SendMessage(User user, int chatId, string body);
    }

    public class SocialService : ISocialService
    {
        ISentimentService sentimentService;
        public SocialService(ISentimentService sentimentService)
        {
            this.sentimentService = sentimentService;
        }

        public Chat CreateChat(User user, string name, ChatType type)
        {
            using MainContext context = new MainContext();

            Chat chat = new Chat()
            {
                Name = name,
                ChatType = type,
                Datetime = DateTime.Now,
                Members = new List<User>() { context.Users.FirstOrDefault(x => x.Id == user.Id) }
            };

            context.Chats.Add(chat);
            context.SaveChanges();

            return chat;
        }

        public ICollection<Chat> GetChatsByUser(User user)
        {
            using MainContext context = new MainContext();

            return context.Chats.Include(x => x.Members).Where(x => x.Members.Contains(user)).ToList();
        }

        public ICollection<Chat> GetChatsByUser(User user, ChatType type)
        {
            using MainContext context = new MainContext();

            return context.Chats.Include(x => x.Members).Where(x => x.Members.Contains(user) && x.ChatType == type).ToList();
        }
        public bool RemoveChat(Chat chat, User user)
        {
            using MainContext context = new MainContext();

            if (chat.ChatType == ChatType.Group)
            {
                return false;
            }

            context.Chats.Include(x => x.Members).FirstOrDefault(x => x.Id == chat.Id).Members.Remove(user);
            context.SaveChanges();

            return true;
        }


        public ICollection<Message> GetMessagesByChat(int chatId, int count, int page)
        {
            using MainContext context = new MainContext();

            return context
                        .Chats
                        .Include(x => x.Messages)
                        .ThenInclude(x => x.Sender)
                        .FirstOrDefault(x => x.Id == chatId)?
                        .Messages?
                        .OrderByDescending(x => x.DateTime)?
                        .Skip((page - 1) * count)?
                        .Take(count)?
                        .OrderBy(x => x.DateTime)?
                        .ToList();
        }

        public ICollection<Message> GetLastMessagesByChat(int chatId, int lastMessageId)
        {
            using MainContext context = new MainContext();

            var lastMessage = context.Messages.FirstOrDefault(x => x.Id == lastMessageId);

            var messages = context.Messages.Where(x => x.ChatId == chatId && lastMessage.DateTime < x.DateTime).Include(x => x.Sender).ToList();

            return messages;
        }

        public Message SendMessage(User user, int chatId, string body)
        {
            MainContext context = new MainContext();

            Message message = new Message()
            {
                Sender = context.Users.FirstOrDefault(x => x.Id == user.Id),
                Body = body,
                DateTime = DateTime.Now,
                Chat = context.Chats.FirstOrDefault(x => x.Id == chatId),
                Sentiment = sentimentService.Predict(body)
            };

            context.Messages.Add(message);
            context.SaveChanges();

            return message;
        }
    }
}
