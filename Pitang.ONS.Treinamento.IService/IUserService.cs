using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Pitang.ONS.Treinamento.IService
{
    public interface IUserService
    {
		public List<UserModel> listUsers();

		public UserModel findUserById(long id);

		public UserModel findUserByUsername(String userName);

		public UserModel findUserByEmail(String email);

		public UserModel addUser(UserModel user);

		public UserModel updateUser(UserModel user);

		public void deleteUser(long id);

		public void deleteById(long id);
	}
}
