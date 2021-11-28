using System.Linq;
using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Enums;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Extensions.ServicesExtensions;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;

        public ChatService(IRepository<Chat> chatRepository) => 
            _chatRepository = chatRepository;

        public Task<Chat> GetChatByIdAsync(Guid chatId) =>
            _chatRepository
                .Query()
                .IncludeMessages()
                .IncludeParticipants()
                .FirstOrDefaultAsync(chat => chat.Id == chatId)!;

        public async Task<Message> AddMessageToChatAsync(Message message)
        {
            var chat = await GetChatByIdAsync(message.ChatId);

            if (chat is null) return null;

            var messages = chat.Messages.ToList();

            messages.Add(message);

            chat.Messages = messages;

            await _chatRepository.SaveChangesAsync();

            return message;
        }
    }
}