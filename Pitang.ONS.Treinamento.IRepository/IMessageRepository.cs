using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> FindConversation(long userId, long contactId);
        Task<IEnumerable<Message>> FindConversationAsync(long userId, long contactId);
        Message DeleteMessageJustForUser(long userId, long messageId);
        Message DeleteMessageForBoth(long userId, long messageId);
    }
}
