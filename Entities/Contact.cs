using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Pitang.ONS.Treinamento.Entities
{
    public class Contact : AuditEntity
    {
        //[Key]
        //public long Id { get; set; }

        [Required(ErrorMessage = "Please, insert a name for you contact")]
        [MinLength(2, ErrorMessage = "The username needs at least 3 characters to be valid")]
        [MaxLength(64, ErrorMessage = "the username is to long, maximum number of characters is 64")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The OwnerId is mandatory")]
        public long OwnerId { get; set; }
        public virtual UserModel Owner { get; set; }

        [Required(ErrorMessage = "The ContactId is mandatory")]
        public long ContactUserId { get; set; }
        public virtual UserModel ContactUser { get; set; }


    }
}
