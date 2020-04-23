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

        public UserModel FindByEmail(string email)
        {
            var query = _entities.AsQueryable();
            query.Select(e => e.Email.Contains(email));

            return query.ToList()[0];
        }

        public UserModel FindByUserName(string username)
        {
            var query = _entities.AsQueryable();
            query.Select(e => e.UserName.Contains(username));

            return query.ToList()[0];
        }
    }
}