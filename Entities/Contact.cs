using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Pitang.ONS.Treinamento.Entities
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Please, type a username")]
        [MinLength(3, ErrorMessage = "The username needs at least 3 characters to be valid")]
        [MaxLength(32, ErrorMessage = "the username is to long, maximum number of characters is 32")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please type your first name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characteres are not allowed")]
        [MinLength(2, ErrorMessage = "Your first name needs at least 2 characters to be valid")]
        [MaxLength(32, ErrorMessage = "the first name is to long, maximum number of characters is 32")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Your last name needs at least 2 characters to be valid")]
        [MaxLength(64, ErrorMessage = "the last name is to long, maximum number of characters is 64")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characteres are not allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, insert you E-mail.")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Please insert a valid E-mail")]
        public string Email { get; set; }
        [Phone]
        public string Telephone1 { get; set; }

        [Phone]
        public string Telephone2 { get; set; }

        [MinLength(4, ErrorMessage = "Your address needs at least 4 characters to be valid")]
        [MaxLength(64, ErrorMessage = "Your address is to long, maximum number of characters is 64")]
        public string Address { get; set; }

        [MinLength(3, ErrorMessage = "Your city needs at least 3 characters to be valid")]
        [MaxLength(64, ErrorMessage = "Your address is to long, maximum number of characters is 64")]
        public string City { get; set; }

        public long UserModelId { get; set; }
        public UserModel UserModel { get; set; }
    }
}
