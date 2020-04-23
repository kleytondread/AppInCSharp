using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.IService
{
	public interface IUserService
	{
		Task<List<UserModel>> ListUsers();

		Task<UserModel> FindUserById(long id);

		Task<UserModel> FindUserByUsername(String userName);

		Task<UserModel> FindUserByEmail(String email);

		Task<UserModel> AddUser(UserModel user);

		UserModel UpdateUser(UserModel user);

		public void DeleteUser(long id);
	}
}
