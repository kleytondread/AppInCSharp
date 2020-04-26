using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IRepository.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public string DeleteMessageJustForUser(long userId, long messageId)
        {
            var message = FindBy(e => e.Id == messageId).ToList()[0];

            if (message != null && message.SenderId == userId)
            {                
                message.IsMessageDeletedForSender = true;
                return "Message deleted for user";
            }
            if (message != null && message.RecipientId == userId)
            {
                message.IsMessageDeletedForRecipient = true;
                return "Message deleted for user";
            } 
            else
            {
                return null;
            }

        }

        public string DeleteMessageForBoth(long userId, long messageId)
        {
            var message = FindBy(e => e.Id == messageId).ToList()[0];
            if (message !=null && message.SenderId == userId)
            {
                message.IsMessageDeletedForSender = true;
                message.IsMessageDeletedForRecipient = true;
                return "Message deleted for user";
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Message> FindConversation(long userId, long contactId)
        {
            var conversation = FindBy(e => 
                    (e.SenderId == userId && e.RecipientId == contactId && e.IsMessageDeletedForSender == false)||
                    (e.SenderId == contactId && e.RecipientId == userId && e.IsMessageDeletedForRecipient == false))
                    .ToList()
                    .OrderBy(e => e.DateOfShippment);

            return conversation;
        }
    }
}
