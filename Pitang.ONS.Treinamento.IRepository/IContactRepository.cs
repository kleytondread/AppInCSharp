using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IContactRepository
    {
        public Contact findById(long id);
        public Contact findByUserName(string userName);
    }
}
