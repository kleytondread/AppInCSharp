using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.IService
{
    public interface IMessageService
    {
        Message SendMessage(Message message);
        Task<Message> SendMessageAsync(Message message);
        Message DeleteMessageForUser(long messageId, long userId);
        Message DeleteMessageForBoth(long messageId, long userId);
        IEnumerable<Message> CreateChatRoom(long userId, long contactId);
        Task<IEnumerable<Message>> CreateChatRoomAsync(long userId, long contactId);
        IEnumerable<Message> CheckNewMessages(IEnumerable<Message> oldMessages, long userId);
        Task<IEnumerable<Message>> CheckNewMessagesAsync(IEnumerable<Message> oldMessages, long userId);
        IEnumerable<Message> UpdateChatRoom(IEnumerable<Message> conversation, long userId, long contactId);
        Task<IEnumerable<Message>> UpdateChatRoomAsync(IEnumerable<Message> oldConversation, long userId, long contactId);
    }
}
