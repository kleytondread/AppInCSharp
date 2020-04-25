using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IRepository.EFRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
