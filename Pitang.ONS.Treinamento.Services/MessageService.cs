using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public IEnumerable<Message> CheckNewMessages(IEnumerable<Message> oldMessages, long userId)
        {
            IEnumerable<Message> allMessages = messageRepository.FindBy(
                    e => (e.SenderId == userId &&
                    e.IsMessageDeletedForSender == false) ||
                    (e.RecipientId == userId &&
                    e.IsMessageDeletedForRecipient == false));

            return allMessages.Except(oldMessages);
        }

        public async Task<IEnumerable<Message>> CheckNewMessagesAsync(IEnumerable<Message> oldMessages, long userId)
        {
            IEnumerable<Message> allMessages = await messageRepository.FindByAsync(
                    e => (e.SenderId == userId &&
                    e.IsMessageDeletedForSender == false) ||
                    (e.RecipientId == userId &&
                    e.IsMessageDeletedForRecipient == false));

            return allMessages.Except(oldMessages);
        }

        public IEnumerable<Message> CreateChatRoom(long userId, long contactId)
        {
            return messageRepository.FindConversation(userId, contactId);
        }

        public async Task<IEnumerable<Message>> CreateChatRoomAsync(long userId, long contactId)
        {
            return await messageRepository.FindConversationAsync(userId, contactId);
        }

        public Message DeleteMessageForBoth(long userId, long messageId)
        {
            return messageRepository.DeleteMessageForBoth(userId, messageId);
        }

        public Message DeleteMessageForUser(long userId, long messageId)
        {
            return messageRepository.DeleteMessageJustForUser(userId, messageId);
        }

        public Message SendMessage(Message message)
        {
            return messageRepository.Add(message);
        }

        public async Task<Message> SendMessageAsync(Message message)
        {
            return await messageRepository.AddAsync(message);
        }

        public IEnumerable<Message> UpdateChatRoom(IEnumerable<Message> oldConversation, long userId, long contactId)
        {
            IEnumerable<Message> allMessages = messageRepository.FindConversation(userId, contactId);
            return allMessages.Except(oldConversation);
        }
        public async Task<IEnumerable<Message>> UpdateChatRoomAsync(IEnumerable<Message> oldConversation, long userId, long contactId)
        {
            IEnumerable<Message> allMessages =  await messageRepository.FindConversationAsync(userId, contactId);
            return allMessages.Except(oldConversation);
        }
    }
} 
