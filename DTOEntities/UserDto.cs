using System;
using System.Collections.Generic;

namespace Pitang.ONS.Treinamento.DTOEntities
{
    public class UserDto
    {
        public long? Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public string ImageUrl { get; set; }
    }
}
