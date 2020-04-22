using Pitang.ONS.Treinamento.Repository;
using Utils.Exceptions;
using Pitang.ONS.Treinamento.Entities;
using System.Collections.Generic;
using Pitang.ONS.Treinamento.IService;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.Services
{
	public class UserService : IUserService
    {
        private UserRepository userRepository;

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
			if (!string.IsNullOrWhiteSpace(user.UserName) && userRepository.findByUserName(user.UserName) != null)
			{
				throw new ExceptionConflict("Nome de usuário informado já existe!");
			}
			if (!string.IsNullOrWhiteSpace(user.Email) && userRepository.findByEmail(user.Email) != null)
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


        public async Task<List<UserModel>> listUsers()
        {
            if (userRepository.Users.Count == 0 || userRepository.Users == null)
            {
                return null;
            }
            return userRepository.Users;
        }

        public UserModel findUserById(long id)
        {
            return userRepository.findById(id);
        }

        public UserModel findUserByUsername(string userName)
        {
            return userRepository.findByUserName(userName);
        }

        public UserModel findUserByEmail(string email)
        {
            return userRepository.findByEmail(email);
        }

        public UserModel addUser(UserModel user)
        {
            validateUser(user);
            checkIntegrity(user);
            return userRepository.save(user);
        }

        //no spring se um obj tinha um id que já contava no BD, ele sobre escrevia a entidade no banco, o mesmo serve aqui?
        public UserModel updateUser(UserModel user) 
        {
            if (user.Id == null)
            {
                throw new ExceptionBadRequest("Necessário informar o id para atualizar!");
            }
            checkIntegrity(user);
            //validateUser(user);
            return userRepository.save(user);
        }

        public void deleteUser(long id)
        {
            Optional<UserModel> user = userRepository.findById(id);
            if (user.isPresent())
            {
                userRepository.deleteById(id);
            }
        }

        public void deleteUser(long id)
        {
            throw new System.NotImplementedException();
        }

        public void deleteById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
