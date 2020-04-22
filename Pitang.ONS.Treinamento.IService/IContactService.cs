using Pitang.ONS.Treinamento.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.IService
{
    public interface IContactService
    {

        public void addContact(Contact contact, long id);

        public void updateContact(Contact contact);

        public void addProfilePicture(UserModel userModel);

        void deleteContact(long id);
    }
}
