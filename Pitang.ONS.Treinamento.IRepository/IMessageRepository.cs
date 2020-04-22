using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IMessageRepository
    {
        public Message findById(long id);
        List<Message> findBySender(UserModel sender);
        List<Message> findByRecipient(UserModel recipient);
        List<Message> findBySenderRecipient(UserModel sender, UserModel recipient);
    }
}
