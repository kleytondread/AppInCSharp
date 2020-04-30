using Pitang.ONS.Treinamento.Entities;
using Pitang.ONS.Treinamento.IRepository;
using Pitang.ONS.Treinamento.IRepository.EFRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pitang.ONS.Treinamento.Repository.Impl
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public bool IsEmailPresent(string email)
        {
            var user = _entities.Any(e => e.Email == email);
            return user;
        }

        public bool IsUserNamePresent(string username)
        {
            var user = _entities.Any(e=> e.UserName == username);
            return user;
        }
    }
}