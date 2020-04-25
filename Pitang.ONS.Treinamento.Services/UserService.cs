using Pitang.ONS.Treinamento.Repository;
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
        private IUserRepository userRepository;
        public UserService(IRepository<UserModel> userRepository)
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
			if (!string.IsNullOrWhiteSpace(user.UserName) && userRepository.FindByUserName(user.UserName) != null)
			{
				throw new ExceptionConflict("Nome de usuário informado já existe!");
			}
			if (!string.IsNullOrWhiteSpace(user.Email) && userRepository.FindByEmail(user.Email) != null)
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

        private bool checkIfContactIsPresent(UserModel user, Contact contact)
        {

            foreach (Contact dbContact in user.Contacts) //verificar com Thiago a prop contact. ela ainda não existe.
            {
                if (dbContact.UserName.Equals(contact.UserName))
                {
                    return true;
                }
            }

            return false;
        }


        public async Task<List<UserModel>> ListUsers()
        {
            if (userRepository.FindAll().Count() == 0|| userRepository.FindAll() == null)
            {
                return null;
            }
            return await Task.FromResult(userRepository.FindAll().ToList()); //ta correto? se sim, fazer no resto
        }

        public async Task<UserModel> FindUserById(long id)
        {
            //meu findBy já retornava uma lista, mas aqui eu preciso converter pra lista de novo?
            return await userRepository.FindByIdAsync(id);
        }

        public async Task<UserModel> FindUserByUsername(string userName)
        {
            return await Task.FromResult(userRepository.FindByUserName(userName));
        }

        public async Task<UserModel> FindUserByEmail(string email)
        {
            return await Task.FromResult(userRepository.FindByEmail(email));
        }

        public async Task<UserModel> AddUser(UserModel user)
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

        public void DeleteUser(long id)
        {
            if (FindUserById(id) != null)
            {
                userRepository.Delete(id);
            }
        }
    }
}
