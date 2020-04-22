using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IUserRepository
    {
        public UserModel findById(long id);
        public UserModel findByUserName(string userName);
        public UserModel findByEmail(string email);
    }
}
