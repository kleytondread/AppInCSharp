using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        UserModel FindByUserName(string username);
        UserModel FindByEmail(string email);
    }
}
