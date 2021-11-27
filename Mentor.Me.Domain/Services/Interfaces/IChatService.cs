using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IChatService
    {
        public Task<Chat> GetChatByIdAsync(Guid chatId);
        public Task<IEnumerable<Chat>> GetUnreadChatsByUserIdAsync(Guid userId);
        public Task<IEnumerable<Chat>> GetReadChatsByUserIdAsync(Guid userId);
        public Task<Message> AddMessageToChatAsync(Message message);
    }
}
