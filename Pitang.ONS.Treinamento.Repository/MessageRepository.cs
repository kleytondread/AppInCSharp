using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IRepository.EFRepository;
using System;
using System.Collections.Generic;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
