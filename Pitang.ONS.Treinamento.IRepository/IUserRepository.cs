using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IRepository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        bool IsUserNamePresent(string username);
        bool IsEmailPresent(string email);
    }
}
