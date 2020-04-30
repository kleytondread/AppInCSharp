using Utils.Exceptions;
using Pitang.ONS.Treinamento.Entities;
using System.Collections.Generic;
using Pitang.ONS.Treinamento.IService;
using System.Threading.Tasks;
using Pitang.ONS.Treinamento.IRepository;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace Pitang.ONS.Treinamento.Services
{
	public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        private void checkIntegrity(UserModel user)
		{
			checkMandatoryFields(user);
			//checkRelations(user);
		}

		private void checkMandatoryFields(UserModel user)
		{
			if (user == null)
			{
				throw new ExceptionBadRequest("Usuário não pode ser nulo!");
			}
			if (string.IsNullOrWhiteSpace(user.Email))
			{
				throw new ExceptionBadRequest("Necessário informar o Email do usuário.");
			}
			if (string.IsNullOrWhiteSpace(user.FirstName))
			{
				throw new ExceptionBadRequest("Necessário informar o Primeiro Nome do usuário.");
			}
			if (string.IsNullOrWhiteSpace(user.Password))
			{
				throw new ExceptionBadRequest("Necessário informar a Senha do usuário.");
			}
			if (string.IsNullOrWhiteSpace(user.UserName))
			{
				throw new ExceptionBadRequest("Necessário informar o Nome do usuário.");
			}
		}

		private void validateUser(UserModel user)
		{
			if (!string.IsNullOrWhiteSpace(user.UserName) && userRepository.IsUserNamePresent(user.UserName) == true)
			{
				throw new ExceptionConflict("Nome de usuário informado já existe!");
			}
			if (!string.IsNullOrWhiteSpace(user.Email) && userRepository.IsEmailPresent(user.Email) == true)
			{
				throw new ExceptionConflict("Email informado já existe!");
			}
		}

        //private void checkRelations(UserModel user)
        //{
        //	if (user.getUserProfile() != null && user.getUserProfile().getId() != null &&
        //			userProfileRepository.findById(user.getUserProfile().getId()) == null)
        //	{
        //		throw new ExceptionBadRequest("Perfil do usuário não encontrado.");
        //	}
        //	else if (user.getUserProfile() != null && user.getUserProfile().getId() == null)
        //	{
        //		user.setUserProfile(null);
        //	}
        //}

        //private bool checkIfContactIsPresent(UserModel user, Contact contact)
        //{
        //    foreach (Contact dbContact in user.Contacts)
        //    {
        //        if (dbContact.UserName.Equals(contact.UserName))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}


        public IEnumerable<UserModel> ListUsers()
        {
            var users = userRepository.FindAll();
            if (users.Count() == 0 || users == null)
            {
                users = null;
            }
            return users;
        }

        public async Task<IEnumerable<UserModel>> ListUsersAsync()
        {
            var users = await userRepository.FindAllAsync();
            if (users.Count() == 0|| users == null)
            {
                users = null;
            }
            return users;
        }

        public async Task<UserModel> FindUserByIdAsync(long id)
        {
            return await userRepository.FindByIdAsync(id);
        }

        public UserModel FindUserById(long id)
        {
            return userRepository.FindById(id);
        }

        public UserModel FindUserByUsername(string userName)
        {
            var user = userRepository.FindBy(e => e.UserName == userName).FirstOrDefault();
            return user;
        }

        public UserModel FindUserByEmail(string email)
        {
            var user = userRepository.FindBy(e => e.Email == email).FirstOrDefault();
            return user;
        }

        public UserModel AddUser(UserModel user)
        {
            validateUser(user);
            checkIntegrity(user);
            return userRepository.Add(user);
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            validateUser(user);
            checkIntegrity(user);
            return await userRepository.AddAsync(user);
        }

        public UserModel UpdateUser(UserModel user) 
        {
            checkIntegrity(user);
            //validateUser(user);
            return userRepository.Updade(user);
        }

        public UserModel DeleteUser(long id)
        {
            UserModel userDeleted = null;
            if (FindUserById(id) != null)
            {
                userDeleted = userRepository.Delete(id);
            }
            return userDeleted;
        }
    }
}
