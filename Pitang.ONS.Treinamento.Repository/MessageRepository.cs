using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using System;
using System.Collections.Generic;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public class MessageRepository : IMessageRepository
    {
        public Message findById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Message> findByRecipient(UserModel recipient)
        {
            throw new NotImplementedException();
        }

        public List<Message> findBySender(UserModel sender)
        {
            throw new NotImplementedException();
        }

        public List<Message> findBySenderRecipient(UserModel sender, UserModel recipient)
        {
            throw new NotImplementedException();
        }
    }
}
