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
		IEnumerable<UserModel> ListUsers();
		Task<IEnumerable<UserModel>> ListUsersAsync();
		UserModel FindUserById(long id);
		Task<UserModel> FindUserByIdAsync(long id);
		UserModel FindUserByUsername(string userName);
		UserModel FindUserByEmail(string email);
		UserModel AddUser(UserModel user);
		Task<UserModel> AddUserAsync(UserModel user);
		UserModel UpdateUser(UserModel user);
		UserModel DeleteUser(long id);
	}
}
