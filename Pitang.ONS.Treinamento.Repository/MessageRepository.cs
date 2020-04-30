using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IRepository.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public Message DeleteMessageJustForUser(long userId, long messageId)
        {
            var message = FindBy(e => e.Id == messageId).FirstOrDefault();

            if (message != null && message.SenderId == userId)
            {                
                message.IsMessageDeletedForSender = true;
            }
            if (message != null && message.RecipientId == userId)
            {
                message.IsMessageDeletedForRecipient = true;
            }
            Updade(message);
            return message;
        }

        public Message DeleteMessageForBoth(long userId, long messageId)
        {
            var message = FindBy(e => e.Id == messageId).FirstOrDefault();
            if (message != null && message.SenderId == userId)
            {
                message.IsMessageDeletedForSender = true;
                message.IsMessageDeletedForRecipient = true;
            }
            _entities.Update(message);
            return message;
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

        public async Task<IEnumerable<Message>> FindConversationAsync(long userId, long contactId)
        {
            var conversation = await FindByAsync(e =>
                    (e.SenderId == userId && e.RecipientId == contactId && e.IsMessageDeletedForSender == false) ||
                    (e.SenderId == contactId && e.RecipientId == userId && e.IsMessageDeletedForRecipient == false));

            return conversation.ToList().OrderBy(e => e.DateOfShippment);
        }
    }
}
