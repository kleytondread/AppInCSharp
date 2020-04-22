using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Pitang.ONS.Treinamento.Repository
{

    //eu preciso criar uma instancia aqui?
    public class UserRepository : IUserRepository
    {
        public List<UserModel> Users { get; set; }

        public UserModel findByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserModel findById(long id)
        {
            throw new NotImplementedException();
        }

        public UserModel findByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
