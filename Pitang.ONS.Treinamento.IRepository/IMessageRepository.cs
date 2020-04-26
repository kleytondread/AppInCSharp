using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> FindConversation(long userId, long contactId);
        string DeleteMessageJustForUser(long userId, long messageId);
        public string DeleteMessageForBoth(long userId, long messageId);
    }
}
