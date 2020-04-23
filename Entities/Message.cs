using System;
using System.ComponentModel.DataAnnotations;

namespace Pitang.ONS.Treinamento.Entities
{
    public class Message : AuditEntity
    {
       // [Key]
       // public long Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public UserModel Sender { get; set; }

        [Required]
        public UserModel Recipient { get; set; }

        [Required]
        public DateTime Date{ get; set; }

        [Required]
        public bool MessageDeletedStatusSender { get; set; }

        [Required]
        public bool MessageDeletedStatusRecipient { get; set; }
    }
}
